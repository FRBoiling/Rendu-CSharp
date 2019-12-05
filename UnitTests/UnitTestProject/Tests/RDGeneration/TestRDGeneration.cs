using NUnit.Framework;
using Rd.CodeFileGeneration;
using Rd.Migration;

namespace UnitTestProject
{
    public partial class Tests
    {
        [Test]
        public void TestGeneration()
        {
            var contextsMigration = new RdComponentsMigration();
            contextsMigration.WorkingDirectory = "../../TestFixtures/Generated/";
            RdDllLoad.DLLNAME = "";
            var files = contextsMigration.Migrate("../Bin");
            MigrationUtils.WriteFiles(files);
        }
    }
}