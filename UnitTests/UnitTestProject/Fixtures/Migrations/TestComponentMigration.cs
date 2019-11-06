using System.Collections.Generic;
using System.IO;
using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;
using Entitas.Migration;
using TestProject.Fixtures.Generation;

namespace TestProject.Fixtures
{
    public class TestComponentMigration : IMigration
    {
        public string version => "0.0.1";

        public string workingDirectory => "where generated files are located";

        public string description => "Adding comment class";

        public MigrationFile[] Migrate(string path)
        {
            var names = @"Entitas.DesperateDevs.CodeGeneration.Plugins.Contexts = Test1,Test2
Entitas.DesperateDevs.CodeGeneration.Plugins.IgnoreNamespaces = true";

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