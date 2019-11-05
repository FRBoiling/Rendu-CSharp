using System.IO;
using System.Linq;
using System.Reflection;
using Entitas;
using NUnit.Framework;

namespace TestProject
{
    public partial class Tests
    {

        [Test]
        public void TestLoadDll()
        {
            byte[] dllBytes = File.ReadAllBytes("./TestComponents.dll");
            byte[] pdbBytes = File.ReadAllBytes("./TestComponents.pdb");
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);

            foreach (var type in assembly.GetTypes())
            {
               var typeInfo = type.GetTypeInfo();
               var iInterface = type.GetInterface("Entitas.IComponent");
               if (iInterface == null)
               {
                   continue;
               }
            }
        }
    }
}