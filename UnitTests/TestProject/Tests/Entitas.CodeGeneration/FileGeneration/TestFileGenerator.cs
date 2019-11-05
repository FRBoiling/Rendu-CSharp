using Entitas.Migration;
using NUnit.Framework;
using TestProject.Fixtures;

namespace TestProject.FileGeneration
{
    public class Tests
    {
        [Test]
        public void TestContextsFileGenerator()
        {
            var contextsMigration = new TestContextsMigration();
            MigrationUtils.WriteFiles(contextsMigration.Migrate("../../TestFixtures/Generated/"));
        }

        [Test]
        public void TestComponentFileGenerator()
        {
            var componentMigration = new TestComponentMigration();
            MigrationUtils.WriteFiles(componentMigration.Migrate("../../TestFixtures/Generated/"));
        }
    }
}