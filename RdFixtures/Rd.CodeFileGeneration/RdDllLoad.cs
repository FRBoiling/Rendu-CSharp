using System.IO;
using System.Reflection;

namespace RDGenerationLib
{
    public class RdDllLoad
    {
        public static Assembly GetComponentsAssembly(string path, string dllName)
        {
//            byte[] dllBytes = File.ReadAllBytes("./Server.Module.dll");
//            byte[] pdbBytes = File.ReadAllBytes("./Server.Module.pdb");
            var dllPath = Path.Combine(path, $"{dllName}.dll");
            var pdbPath = Path.Combine(path, $"{dllName}.pdb");
            var dllBytes = File.ReadAllBytes(dllPath);
            var pdbBytes = File.ReadAllBytes(pdbPath);
            var assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }
    }
}