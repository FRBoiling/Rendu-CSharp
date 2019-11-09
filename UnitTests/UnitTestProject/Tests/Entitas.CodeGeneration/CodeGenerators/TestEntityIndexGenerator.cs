using NUnit.Framework;
using Rd.CodeGeneration;
using Rd.Plugins.EntityIndex.CodeGenerators;

namespace UnitTestProject
{
    public partial class Tests
    {
        [Test]
        public void TestEntityIndexGenerator()
        {
            var generator = new EntityIndexGenerator();
            var files = generator.Generate(new CodeGeneratorData[0]);

            Assert.AreEqual(files.Length, 0);
        }
    }
}