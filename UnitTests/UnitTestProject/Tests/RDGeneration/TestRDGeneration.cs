using Entitas.Migration;
using NUnit.Framework;
using RDGenerationLib;

namespace TestProject
{
    public partial class Tests
    {
        [Test]
        public void TestGeneration()
        {
            var contextsMigration = new RdComponentsMigration();
            MigrationUtils.WriteFiles(contextsMigration.Migrate("../../../Bin/Shared/netcoreapp3.0"));
        }
    }
}