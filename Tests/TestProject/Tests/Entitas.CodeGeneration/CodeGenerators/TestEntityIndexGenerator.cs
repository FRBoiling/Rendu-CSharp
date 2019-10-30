using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;
using NUnit.Framework;

namespace TestProject
{
    public partial class Tests
    {
       
        [Test]
        public void TestEntityIndexGenerator ()
        {
            var generator = new EntityIndexGenerator();
            var files = generator.Generate(new CodeGeneratorData[0]);
            
            Assert.AreEqual(  files.Length, 0);
        }
  
    }
}