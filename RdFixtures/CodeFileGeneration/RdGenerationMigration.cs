using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Entitas.Attributes;
using Rd.CodeGeneration;
using Rd.Logging;
using Rd.Migration;
using Rd.Plugins.Component;
using Rd.Plugins.Component.CodeGenerators;
using Rd.Plugins.Component.DataProviders;
using Rd.Plugins.Context;
using Rd.Plugins.Context.CodeGenerators;
using Rd.Plugins.Context.DataProviders;
using Rd.Plugins.Entity.CodeGenerators;

namespace Rd.CodeFileGeneration
{
    public class RdComponentsMigration : IMigration
    {
        private const string CONTEXTS_PREFERENCES = "Rendu.CodeGeneration.Plugins.Contexts = ${contextNames}";
        private const string COMPONENT_PREFERENCES = "Rendu.CodeGeneration.Plugins.IgnoreNamespaces = true";

        public string version => "0.0.1";

        public string workingDirectory => "../Generated";

        public string description => "Adding comment class";

        public string WorkingDirectory = string.Empty;

        private readonly static Logger _logger = fabl.GetLogger(typeof(RdComponentsMigration));

        public MigrationFile[] Migrate(string path)
        {
            if (string.IsNullOrEmpty(WorkingDirectory))
            {
                return null;
            }

            var dllPath = Path.Combine(path, $"{RdDllLoad.DLLNAME}{RdDllLoad.DLLSUFFIX}");
            var assembly = Assembly.LoadFrom(dllPath);
            var contextNameList = new List<string>();
            var componentsList = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var attributes = type.GetCustomAttributes(typeof(ContextAttribute), false);

                foreach (var attribute in attributes)
                {
                    var contextAttribute = (ContextAttribute)attribute;
                    if (!contextNameList.Contains(contextAttribute.contextName)) contextNameList.Add(contextAttribute.contextName);
                }

                var iInterface = type.GetInterface("Entitas.IComponent");
                if (iInterface == null) continue;

                if (!componentsList.Contains(type)) componentsList.Add(type);
            }

            if (componentsList.Count == 0)
            {
                return null;
            }

            var contextNameStr = string.Empty;
            foreach (var contextName in contextNameList)
                if (string.IsNullOrEmpty(contextNameStr))
                    contextNameStr = contextName;
                else
                    contextNameStr = $"{contextNameStr},{contextName}";

            var contextsPreferencesStr = CONTEXTS_PREFERENCES.Replace("${contextNames}", contextNameStr);
            var contextsPreferences = new RdPreferences(contextsPreferencesStr);
            /////
            var codeGenFiles = new List<CodeGenFile>();
            var contextDataProvider = new ContextDataProvider();
            contextDataProvider.Configure(contextsPreferences);
            var contextDataArr = (ContextData[])contextDataProvider.GetData();

            var contextsGenerator = new ContextsGenerator();
            var contextsFile = contextsGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(contextsFile);

            var contextGenerator = new ContextGenerator();
            var contextFile = contextGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(contextFile);

            var contextAttributeGenerator = new ContextAttributeGenerator();
            var contextAttributeFile = contextAttributeGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(contextAttributeFile);

            var contextMatcherGenerator = new ContextMatcherGenerator();
            var contextMatcherFile = contextMatcherGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(contextMatcherFile);

            var entityGenerator = new EntityGenerator();
            var entityFile = entityGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(entityFile);
            /////
            var componentsPreferences = new RdPreferences($"{contextsPreferencesStr}{"\n"}{COMPONENT_PREFERENCES}");

            var componentDataProvider = new ComponentDataProvider(componentsList.ToArray());
            componentDataProvider.Configure(componentsPreferences);
            var componentDataArr = (ComponentData[])componentDataProvider.GetData();

            var componentEntityApiGenerator = new ComponentEntityApiGenerator();
            var componentsFile = componentEntityApiGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentsFile);

            var componentMatcherApiGenerator = new ComponentMatcherApiGenerator();
            componentsFile = componentMatcherApiGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentsFile);

            var componentLookupGenerator = new ComponentLookupGenerator();
            var componentLookupFile = componentLookupGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentLookupFile);

            var migratedFiles = new List<MigrationFile>();

            foreach (var file in codeGenFiles)
            {
                var fileFullName = Path.Combine(WorkingDirectory, file.fileName);

                var migrationFile = new MigrationFile(fileFullName, file.fileContent);
                migratedFiles.Add(migrationFile);
            }

            return migratedFiles.ToArray();
        }
    }
}