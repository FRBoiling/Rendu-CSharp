using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Rd.CodeGeneration;
using Rd.Logging;
using Rd.Serialization;
using Rd.Utils;

namespace Rd.CodeGenerator
{
  public static class CodeGeneratorUtil
  {
    private static readonly Logger _logger = fabl.GetLogger(typeof (CodeGeneratorUtil).FullName);

    public static CodeGenerator CodeGeneratorFromPreferences(
      Preferences preferences)
    {
      ICodeGenerationPlugin[] instances = CodeGeneratorUtil.LoadFromPlugins(preferences);
      CodeGeneratorConfig andConfigure = preferences.CreateAndConfigure<CodeGeneratorConfig>();
      IPreProcessor[] enabledInstancesOf1 = CodeGeneratorUtil.GetEnabledInstancesOf<IPreProcessor>(instances, andConfigure.preProcessors);
      IDataProvider[] enabledInstancesOf2 = CodeGeneratorUtil.GetEnabledInstancesOf<IDataProvider>(instances, andConfigure.dataProviders);
      ICodeGenerator[] enabledInstancesOf3 = CodeGeneratorUtil.GetEnabledInstancesOf<ICodeGenerator>(instances, andConfigure.codeGenerators);
      IPostProcessor[] enabledInstancesOf4 = CodeGeneratorUtil.GetEnabledInstancesOf<IPostProcessor>(instances, andConfigure.postProcessors);
      CodeGeneratorUtil.configure((ICodeGenerationPlugin[]) enabledInstancesOf1, preferences);
      CodeGeneratorUtil.configure((ICodeGenerationPlugin[]) enabledInstancesOf2, preferences);
      CodeGeneratorUtil.configure((ICodeGenerationPlugin[]) enabledInstancesOf3, preferences);
      CodeGeneratorUtil.configure((ICodeGenerationPlugin[]) enabledInstancesOf4, preferences);
      bool trackHooks = false;
      if (preferences.HasKey("Jenny.TrackHooks"))
        trackHooks = preferences["Jenny.TrackHooks"] == "true";
      return new CodeGenerator(enabledInstancesOf1, enabledInstancesOf2, enabledInstancesOf3, enabledInstancesOf4, trackHooks);
    }

    private static void configure(ICodeGenerationPlugin[] plugins, Preferences preferences)
    {
      foreach (IConfigurable configurable in plugins.OfType<IConfigurable>())
        configurable.Configure(preferences);
    }

    public static ICodeGenerationPlugin[] LoadFromPlugins(
      Preferences preferences)
    {
      CodeGeneratorConfig andConfigure = preferences.CreateAndConfigure<CodeGeneratorConfig>();
      AssemblyResolver assemblyResolver = new AssemblyResolver(false, andConfigure.searchPaths);
      foreach (string plugin in andConfigure.plugins)
        assemblyResolver.Load(plugin);
      return ((IEnumerable<Type>) assemblyResolver.GetTypes().GetNonAbstractTypes<ICodeGenerationPlugin>()).Select<Type, ICodeGenerationPlugin>((Func<Type, ICodeGenerationPlugin>) (type =>
      {
        try
        {
          return (ICodeGenerationPlugin) Activator.CreateInstance(type);
        }
        catch (TypeLoadException ex)
        {
          CodeGeneratorUtil._logger.Warn(ex.Message);
        }
        return (ICodeGenerationPlugin) null;
      })).Where<ICodeGenerationPlugin>((Func<ICodeGenerationPlugin, bool>) (instance => instance != null)).ToArray<ICodeGenerationPlugin>();
    }

    public static T[] GetOrderedInstancesOf<T>(ICodeGenerationPlugin[] instances) where T : ICodeGenerationPlugin
    {
      return instances.OfType<T>().OrderBy<T, int>((Func<T, int>) (instance => instance.priority)).ThenBy<T, string>((Func<T, string>) (instance => instance.GetType().ToCompilableString())).ToArray<T>();
    }

    public static string[] GetOrderedTypeNamesOf<T>(ICodeGenerationPlugin[] instances) where T : ICodeGenerationPlugin
    {
      return ((IEnumerable<T>) CodeGeneratorUtil.GetOrderedInstancesOf<T>(instances)).Select<T, string>((Func<T, string>) (instance => instance.GetType().ToCompilableString())).ToArray<string>();
    }

    public static T[] GetEnabledInstancesOf<T>(
      ICodeGenerationPlugin[] instances,
      string[] typeNames)
      where T : ICodeGenerationPlugin
    {
      return ((IEnumerable<T>) CodeGeneratorUtil.GetOrderedInstancesOf<T>(instances)).Where<T>((Func<T, bool>) (instance => ((IEnumerable<string>) typeNames).Contains<string>(instance.GetType().ToCompilableString()))).ToArray<T>();
    }

    public static string[] GetAvailableNamesOf<T>(
      ICodeGenerationPlugin[] instances,
      string[] typeNames)
      where T : ICodeGenerationPlugin
    {
      return ((IEnumerable<string>) CodeGeneratorUtil.GetOrderedTypeNamesOf<T>(instances)).Where<string>((Func<string, bool>) (typeName => !((IEnumerable<string>) typeNames).Contains<string>(typeName))).ToArray<string>();
    }

    public static string[] GetUnavailableNamesOf<T>(
      ICodeGenerationPlugin[] instances,
      string[] typeNames)
      where T : ICodeGenerationPlugin
    {
      string[] orderedTypeNames = CodeGeneratorUtil.GetOrderedTypeNamesOf<T>(instances);
      return ((IEnumerable<string>) typeNames).Where<string>((Func<string, bool>) (typeName => !((IEnumerable<string>) orderedTypeNames).Contains<string>(typeName))).ToArray<string>();
    }

    public static Dictionary<string, string> GetDefaultProperties(
      ICodeGenerationPlugin[] instances,
      CodeGeneratorConfig config)
    {
      return new Dictionary<string, string>().Merge<string, string>(CodeGeneratorUtil.GetEnabledInstancesOf<IPreProcessor>(instances, config.preProcessors).OfType<IConfigurable>().Concat<IConfigurable>(CodeGeneratorUtil.GetEnabledInstancesOf<IDataProvider>(instances, config.dataProviders).OfType<IConfigurable>()).Concat<IConfigurable>(CodeGeneratorUtil.GetEnabledInstancesOf<ICodeGenerator>(instances, config.codeGenerators).OfType<IConfigurable>()).Concat<IConfigurable>(CodeGeneratorUtil.GetEnabledInstancesOf<IPostProcessor>(instances, config.postProcessors).OfType<IConfigurable>()).Select<IConfigurable, Dictionary<string, string>>((Func<IConfigurable, Dictionary<string, string>>) (instance => instance.defaultProperties)).ToArray<Dictionary<string, string>>());
    }

    public static string[] BuildSearchPaths(string[] searchPaths, string[] additionalSearchPaths)
    {
      return ((IEnumerable<string>) searchPaths).Concat<string>((IEnumerable<string>) additionalSearchPaths).Where<string>(new Func<string, bool>(Directory.Exists)).ToArray<string>();
    }

    public static void AutoImport(CodeGeneratorConfig config, params string[] searchPaths)
    {
      string[] array = ((IEnumerable<Type>) ((IEnumerable<Assembly>) AssemblyResolver.GetAssembliesContainingType<ICodeGenerationPlugin>(true, searchPaths)).GetAllTypes().GetNonAbstractTypes<ICodeGenerationPlugin>()).Select<Type, Assembly>((Func<Type, Assembly>) (type => type.Assembly)).Distinct<Assembly>().Select<Assembly, string>((Func<Assembly, string>) (assembly => assembly.CodeBase.MakePathRelativeTo(Directory.GetCurrentDirectory()))).ToArray<string>();
      HashSet<string> currentFullPaths = new HashSet<string>(((IEnumerable<string>) config.searchPaths).Select<string, string>(new Func<string, string>(Path.GetFullPath)));
      IEnumerable<string> second = ((IEnumerable<string>) array).Select<string, string>(new Func<string, string>(Path.GetDirectoryName)).Where<string>((Func<string, bool>) (path => !currentFullPaths.Contains(path)));
      config.searchPaths = ((IEnumerable<string>) config.searchPaths).Concat<string>(second).Distinct<string>().OrderBy<string, string>((Func<string, string>) (path => path)).ToArray<string>();
      config.plugins = ((IEnumerable<string>) array).Select<string, string>(new Func<string, string>(Path.GetFileNameWithoutExtension)).Distinct<string>().OrderBy<string, string>((Func<string, string>) (plugin => plugin)).ToArray<string>();
    }
  }
}