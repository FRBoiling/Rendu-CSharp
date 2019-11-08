using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rd.CodeGeneration;
using Rd.Logging;
using Rd.Serialization;
using Rd.Utils;

namespace Rd.CodeGenerator
{
    public static class CodeGeneratorUtil
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(CodeGeneratorUtil).FullName);

        public static CodeGenerator CodeGeneratorFromPreferences(
            Preferences preferences)
        {
            var instances = LoadFromPlugins(preferences);
            var andConfigure = preferences.CreateAndConfigure<CodeGeneratorConfig>();
            var enabledInstancesOf1 = GetEnabledInstancesOf<IPreProcessor>(instances, andConfigure.preProcessors);
            var enabledInstancesOf2 = GetEnabledInstancesOf<IDataProvider>(instances, andConfigure.dataProviders);
            var enabledInstancesOf3 = GetEnabledInstancesOf<ICodeGenerator>(instances, andConfigure.codeGenerators);
            var enabledInstancesOf4 = GetEnabledInstancesOf<IPostProcessor>(instances, andConfigure.postProcessors);
            configure(enabledInstancesOf1, preferences);
            configure(enabledInstancesOf2, preferences);
            configure(enabledInstancesOf3, preferences);
            configure(enabledInstancesOf4, preferences);
            var trackHooks = false;
            if (preferences.HasKey("Jenny.TrackHooks"))
                trackHooks = preferences["Jenny.TrackHooks"] == "true";
            return new CodeGenerator(enabledInstancesOf1, enabledInstancesOf2, enabledInstancesOf3, enabledInstancesOf4, trackHooks);
        }

        private static void configure(ICodeGenerationPlugin[] plugins, Preferences preferences)
        {
            foreach (var configurable in plugins.OfType<IConfigurable>())
                configurable.Configure(preferences);
        }

        public static ICodeGenerationPlugin[] LoadFromPlugins(
            Preferences preferences)
        {
            var andConfigure = preferences.CreateAndConfigure<CodeGeneratorConfig>();
            var assemblyResolver = new AssemblyResolver(false, andConfigure.searchPaths);
            foreach (var plugin in andConfigure.plugins)
                assemblyResolver.Load(plugin);
            return assemblyResolver.GetTypes().GetNonAbstractTypes<ICodeGenerationPlugin>().Select(type =>
            {
                try
                {
                    return (ICodeGenerationPlugin) Activator.CreateInstance(type);
                }
                catch (TypeLoadException ex)
                {
                    _logger.Warn(ex.Message);
                }

                return (ICodeGenerationPlugin) null;
            }).Where(instance => instance != null).ToArray();
        }

        public static T[] GetOrderedInstancesOf<T>(ICodeGenerationPlugin[] instances) where T : ICodeGenerationPlugin
        {
            return instances.OfType<T>().OrderBy(instance => instance.priority).ThenBy(instance => instance.GetType().ToCompilableString()).ToArray();
        }

        public static string[] GetOrderedTypeNamesOf<T>(ICodeGenerationPlugin[] instances) where T : ICodeGenerationPlugin
        {
            return GetOrderedInstancesOf<T>(instances).Select(instance => instance.GetType().ToCompilableString()).ToArray();
        }

        public static T[] GetEnabledInstancesOf<T>(
            ICodeGenerationPlugin[] instances,
            string[] typeNames)
            where T : ICodeGenerationPlugin
        {
            return GetOrderedInstancesOf<T>(instances).Where(instance => typeNames.Contains(instance.GetType().ToCompilableString())).ToArray();
        }

        public static string[] GetAvailableNamesOf<T>(
            ICodeGenerationPlugin[] instances,
            string[] typeNames)
            where T : ICodeGenerationPlugin
        {
            return GetOrderedTypeNamesOf<T>(instances).Where(typeName => !typeNames.Contains(typeName)).ToArray();
        }

        public static string[] GetUnavailableNamesOf<T>(
            ICodeGenerationPlugin[] instances,
            string[] typeNames)
            where T : ICodeGenerationPlugin
        {
            var orderedTypeNames = GetOrderedTypeNamesOf<T>(instances);
            return typeNames.Where(typeName => !orderedTypeNames.Contains(typeName)).ToArray();
        }

        public static Dictionary<string, string> GetDefaultProperties(
            ICodeGenerationPlugin[] instances,
            CodeGeneratorConfig config)
        {
            return new Dictionary<string, string>().Merge(GetEnabledInstancesOf<IPreProcessor>(instances, config.preProcessors).OfType<IConfigurable>()
                .Concat(GetEnabledInstancesOf<IDataProvider>(instances, config.dataProviders).OfType<IConfigurable>())
                .Concat(GetEnabledInstancesOf<ICodeGenerator>(instances, config.codeGenerators).OfType<IConfigurable>())
                .Concat(GetEnabledInstancesOf<IPostProcessor>(instances, config.postProcessors).OfType<IConfigurable>()).Select(instance => instance.defaultProperties).ToArray());
        }

        public static string[] BuildSearchPaths(string[] searchPaths, string[] additionalSearchPaths)
        {
            return searchPaths.Concat(additionalSearchPaths).Where(Directory.Exists).ToArray();
        }

        public static void AutoImport(CodeGeneratorConfig config, params string[] searchPaths)
        {
            var array = AssemblyResolver.GetAssembliesContainingType<ICodeGenerationPlugin>(true, searchPaths).GetAllTypes().GetNonAbstractTypes<ICodeGenerationPlugin>()
                .Select(type => type.Assembly).Distinct().Select(assembly => assembly.CodeBase.MakePathRelativeTo(Directory.GetCurrentDirectory())).ToArray();
            var currentFullPaths = new HashSet<string>(config.searchPaths.Select(Path.GetFullPath));
            var second = array.Select(Path.GetDirectoryName).Where(path => !currentFullPaths.Contains(path));
            config.searchPaths = config.searchPaths.Concat(second).Distinct().OrderBy(path => path).ToArray();
            config.plugins = array.Select(Path.GetFileNameWithoutExtension).Distinct().OrderBy(plugin => plugin).ToArray();
        }
    }
}