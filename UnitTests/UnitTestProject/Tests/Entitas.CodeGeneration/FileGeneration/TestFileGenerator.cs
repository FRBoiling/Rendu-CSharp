using NUnit.Framework;
using Rd.Migration;
using UnitTestProject.Fixtures.Migrations;

namespace UnitTestProject
{
    public partial class Tests
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