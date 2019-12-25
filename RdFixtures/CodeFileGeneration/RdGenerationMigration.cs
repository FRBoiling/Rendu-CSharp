using System;
using System.Collections.Generic;
using System.IO;
using Entitas;
using Entitas.Attributes;
using Rd.CodeGeneration;
using Rd.Logging;
using Rd.Migration;
using Rd.Plugins;
using Rd.Utils;

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


            var assembly = RdDllLoad.GetDllAssembly(path, RdDllLoad.DLLNAME);
            if (assembly == null)
            {
                return null;
            }
            var contextNameList = new List<string>();
            var componentsList = new List<Type>();
            var structList = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                //var attributes = type.GetCustomAttributes(typeof(ContextAttribute), false);
                //foreach (var attribute in attributes)
                //{
                //    var contextAttribute = (ContextAttribute)attribute;
                //    if (!contextNameList.Contains(contextAttribute.contextName)) contextNameList.Add(contextAttribute.contextName);
                //}
                var attributesData = type.GetCustomAttributesData();
                foreach (var attribute in attributesData)
                {
                    if (attribute.AttributeType.Name != typeof(ContextAttribute).Name)
                    {
                        continue;
                    }
                    foreach (var item in attribute.ConstructorArguments)
                    {
                        var contextName = item.Value as string;
                        if (contextName == null)
                        {
                            continue;
                        }
                        if (!contextNameList.Contains(contextName)) contextNameList.Add(contextName);
                    }
                }


                if (!type.ImplementsInterface(typeof(IComponent).Name))
                {
                    if (!structList.Contains(type)) structList.Add(type);
                    continue;
                }

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

            var featureGenerator = new FeatureGenerator();
            var featureFile = featureGenerator.Generate(contextDataArr);
            codeGenFiles.AddRange(featureFile);

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

            
            ///////
            var componentsPreferences = new RdPreferences($"{contextsPreferencesStr}{"\n\t"}{COMPONENT_PREFERENCES}");

            var componentDataProvider = new ComponentDataProvider(componentsList.ToArray());
            componentDataProvider.Configure(componentsPreferences);
            var componentDataArr = (ComponentData[])componentDataProvider.GetData();

            //var componentEntityApiInterfaceGenerator = new ComponentEntityApiInterfaceGenerator();
            //componentEntityApiInterfaceGenerator.Configure(componentsPreferences);
            //var componentEntityApiInterface = componentEntityApiInterfaceGenerator.Generate(componentDataArr);
            //codeGenFiles.AddRange(componentEntityApiInterface);
                                 
            var componentContextApiGenerator = new ComponentContextApiGenerator();
            componentContextApiGenerator.Configure(componentsPreferences);
            var componentContext = componentContextApiGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentContext);

            var componentEntityApiGenerator = new ComponentEntityApiGenerator();
            componentEntityApiGenerator.Configure(componentsPreferences);
            var componentEntity = componentEntityApiGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentEntity);

            var componentMatcherApiGenerator = new ComponentMatcherApiGenerator();
            componentMatcherApiGenerator.Configure(componentsPreferences);
            var componentMatcher = componentMatcherApiGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentMatcher);

            var componentLookupGenerator = new ComponentLookupGenerator();
            componentLookupGenerator.Configure(componentsPreferences);
            var componentLookupFile = componentLookupGenerator.Generate(componentDataArr);
            codeGenFiles.AddRange(componentLookupFile);

            /////
            var entityIndexProvider = new EntityIndexDataProvider(componentsList.ToArray());
            entityIndexProvider.Configure(componentsPreferences);
            var entityIndexDateArr = (EntityIndexData[])entityIndexProvider.GetData();

            var entityIndexGenerator = new EntityIndexGenerator();
            entityIndexGenerator.Configure(componentsPreferences);
            var entityIndexFile = entityIndexGenerator.Generate(entityIndexDateArr);
            codeGenFiles.AddRange(entityIndexFile);

            var migratedFiles = new Dictionary<string, MigrationFile>();

            foreach (var file in codeGenFiles)
            {
                var fileFullName = Path.Combine(WorkingDirectory, file.fileName);
                if (!migratedFiles.TryGetValue(fileFullName, out var migrationFile))
                {
                    migrationFile = new MigrationFile(fileFullName, file.fileContent);
                    migratedFiles.Add(fileFullName, migrationFile);
                }
                else
                {
                    migrationFile.fileContent = $"{migrationFile.fileContent}\n{file.fileContent}";
                }

            }
            var fileList = new List<MigrationFile>();
            foreach (var item in migratedFiles)
            {
                fileList.Add(item.Value);
            }
            return fileList.ToArray();
        }

        public void SetLoadName(string assemblyName)
        {
            RdDllLoad.SetLoadName(assemblyName);
        }
    }
}