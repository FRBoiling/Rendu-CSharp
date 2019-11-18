using NUnit.Framework;
using Rd.Migration;
using RDGenerationLib;

namespace UnitTestProject
{
    public partial class Tests
    {
        [Test]
        public void TestGeneration()
        {
            var contextsMigration = new RdComponentsMigration();
            MigrationUtils.WriteFiles(contextsMigration.Migrate("./"));
        }
    }
}