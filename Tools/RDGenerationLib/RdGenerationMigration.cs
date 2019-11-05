using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DesperateDevs.CodeGeneration;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Entitas.CodeGeneration.Plugins;
using Entitas.Migration;

namespace RDGenerationLib
{
    public class RdComponentsMigration : IMigration
    {
        public string version
        {
            get { return "0.0.1"; }
        }

        public string workingDirectory
        {
            get { return "../../../Shared/Generated"; }
        }

        public string description
        {
            get { return "Adding comment class"; }
        }

        const string CONTEXTS_PREFERENCES = "Entitas.CodeGeneration.Plugins.Contexts = ${contextNames}";
        const string COMPONENT_PREFERENCES = "Entitas.CodeGeneration.Plugins.IgnoreNamespaces = true";

        public MigrationFile[] Migrate(string path)
        {
            string dllName = "Components";
            var assembly = RdDllLoad.GetComponentsAssembly(path, dllName);

            List<string> contextNameList = new List<string>();
            List<Type> componentsList = new List<Type>();

            foreach (Type type in assembly.GetTypes())
            {
                object[] attributes = type.GetCustomAttributes(typeof(ContextAttribute), false);

                foreach (var attribute in attributes)
                {
                    ContextAttribute contextAttribute = (ContextAttribute) attribute;
                    if (!contextNameList.Contains(contextAttribute.contextName))
                    {
                        contextNameList.Add(contextAttribute.contextName);
                    }
                }

                var iInterface = type.GetInterface("Entitas.IComponent");
                if (iInterface == null)
                {
                    continue;
                }

                if (!componentsList.Contains(type))
                {
                    componentsList.Add(type);
                }
            }

            var contextNameStr = string.Empty;
            foreach (var contextName in contextNameList)
            {
                if (string.IsNullOrEmpty(contextNameStr))
                {
                    contextNameStr = contextName;
                }
                else
                {
                    contextNameStr = $"{contextNameStr},{contextName}";
                }
            }

            var contextsPreferencesStr = CONTEXTS_PREFERENCES.Replace("${contextNames}", contextNameStr);
            var contextsPreferences = new RdPreferences(contextsPreferencesStr);
/////
            List<CodeGenFile> codeGenFiles = new List<CodeGenFile>();
            var contextDataProvider = new ContextDataProvider();
            contextDataProvider.Configure(contextsPreferences);
            var contextDataArr = (ContextData[]) contextDataProvider.GetData();

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
            var componentDataArr = (ComponentData[]) componentDataProvider.GetData();

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
                var fileFullName = Path.Combine(workingDirectory, file.fileName);

                var migrationFile = new MigrationFile(fileFullName, file.fileContent);
                migratedFiles.Add(migrationFile);
            }

            return migratedFiles.ToArray();
        }
    }
}