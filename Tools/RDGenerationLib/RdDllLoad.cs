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
            string dllPath = Path.Combine(path, $"{dllName}.dll");
            string pdbPath = Path.Combine(path, $"{dllName}.pdb");
            byte[] dllBytes = File.ReadAllBytes(dllPath);
            byte[] pdbBytes = File.ReadAllBytes(pdbPath);
            Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }
    }
}