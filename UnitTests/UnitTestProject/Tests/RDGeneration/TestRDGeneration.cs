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
            MigrationUtils.WriteFiles(contextsMigration.Migrate("./"));
        }
    }
}