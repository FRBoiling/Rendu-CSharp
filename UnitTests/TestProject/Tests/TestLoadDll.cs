using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace TestProject
{
    public partial class Tests
    {
        [Test]
        public void TestLoadDll()
        {
            var dllBytes = File.ReadAllBytes("./TestComponents.dll");
            var pdbBytes = File.ReadAllBytes("./TestComponents.pdb");
            var assembly = Assembly.Load(dllBytes, pdbBytes);

            foreach (var type in assembly.GetTypes())
            {
                var typeInfo = type.GetTypeInfo();
                var iInterface = type.GetInterface("Entitas.IComponent");
                if (iInterface == null) continue;
            }
        }
    }
}