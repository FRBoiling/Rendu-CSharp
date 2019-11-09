using System.Collections.Generic;
using System.IO;
using Rd.CodeGeneration;
using Rd.Migration;
using Rd.Plugins.Component.CodeGenerators;
using Rd.Plugins.Context;
using Rd.Plugins.Context.CodeGenerators;
using Rd.Plugins.Context.DataProviders;
using Rd.Plugins.Entity.CodeGenerators;
using UnitTestProject.Fixtures.Preferences;

namespace UnitTestProject.Fixtures.Migrations
{
    public class TestContextsMigration : IMigration
    {
        public string version => "0.0.1";

        public string workingDirectory => "where generated files are located";

        public string description => "Adding contexts class";

        public MigrationFile[] Migrate(string path)
        {
            var names = "Entitas.Rd.CodeGeneration.Rd.Plugins.Contexts = Test1,Test2";
            var provider = new ContextDataProvider();
            provider.Configure(new TestPreferences(names));

            var dataArr = (ContextData[]) provider.GetData();

            var codeGenFiles = new List<CodeGenFile>();

            var contextsGenerator = new ContextsGenerator();
            var contextsFile = contextsGenerator.Generate(dataArr);
            codeGenFiles.AddRange(contextsFile);

            var contextGenerator = new ContextGenerator();
            var contextFile = contextGenerator.Generate(dataArr);
            codeGenFiles.AddRange(contextFile);

            var contextAttributeGenerator = new ContextAttributeGenerator();
            var contextAttributeFile = contextAttributeGenerator.Generate(dataArr);
            codeGenFiles.AddRange(contextAttributeFile);

            var contextMatcherGenerator = new ContextMatcherGenerator();
            var contextMatcherFile = contextMatcherGenerator.Generate(dataArr);
            codeGenFiles.AddRange(contextMatcherFile);

            var entityGenerator = new EntityGenerator();
            var entityFile = entityGenerator.Generate(dataArr);
            codeGenFiles.AddRange(entityFile);

            var componentLookupGenerator = new ComponentLookupGenerator();
            var componentLookupFile = componentLookupGenerator.Generate(dataArr);
            codeGenFiles.AddRange(componentLookupFile);

            var migratedFiles = new List<MigrationFile>();

            foreach (var file in codeGenFiles)
            {
                var fileFullName = Path.Combine(path, file.fileName);

                var migrationFile = new MigrationFile(fileFullName, file.fileContent);
                migratedFiles.Add(migrationFile);
            }

            return migratedFiles.ToArray();
        }
    }
}