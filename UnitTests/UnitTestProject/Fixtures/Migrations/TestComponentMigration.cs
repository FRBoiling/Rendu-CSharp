using System.Collections.Generic;
using System.IO;
using Rd.CodeGeneration;
using Rd.Migration;
using Rd.Plugins.Component.CodeGenerators;
using TestComponents;
using UnitTestProject.Fixtures.Generation;
using UnitTestProject.Fixtures.Preferences;

namespace UnitTestProject.Fixtures.Migrations
{
    public class TestComponentMigration : IMigration
    {
        public string version => "0.0.1";

        public string workingDirectory => "where generated files are located";

        public string description => "Adding comment class";

        public MigrationFile[] Migrate(string path)
        {
            var names = @"Entitas.Rendu.CodeGeneration.Plugins.Contexts = Test1,Test2
Entitas.Rendu.CodeGeneration.Plugins.IgnoreNamespaces = true";

            var dataArr = TestDataGeneration.getMultipleData<TestNormalComponent>(new TestPreferences(names));

            var codeGenFiles = new List<CodeGenFile>();

            var componentEntityApiGenerator = new ComponentEntityApiGenerator();
            var componentsFile = componentEntityApiGenerator.Generate(dataArr);
            codeGenFiles.AddRange(componentsFile);

            var componentMatcherApiGenerator = new ComponentMatcherApiGenerator();
            componentsFile = componentMatcherApiGenerator.Generate(dataArr);
            codeGenFiles.AddRange(componentsFile);

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