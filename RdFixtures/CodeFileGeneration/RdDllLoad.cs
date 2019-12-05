using Rd.Logging;
using System;
using System.IO;
using System.Reflection;

namespace Rd.CodeFileGeneration
{
    public class RdDllLoad
    {
        public enum ErrorCode
        {
            Success,
            DLLError,
            PDBError,
        }
        private readonly static Logger _logger = fabl.GetLogger(typeof(RdDllLoad));

        public static string DLLNAME = "Components";
        public const string DLLSUFFIX = ".dll";
        public const string PDBSUFFIX = ".pdb";
        public static Assembly GetDllAssembly(string path, string dllName)
        {
            //            byte[] dllBytes = File.ReadAllBytes("./Server.Module.dll");
            //            byte[] pdbBytes = File.ReadAllBytes("./Server.Module.pdb");
            var dllPath = Path.Combine(path, $"{dllName}{DLLSUFFIX}");
            var pdbPath = Path.Combine(path, $"{dllName}{PDBSUFFIX}");
            FileInfo dllFileInfo = new FileInfo(dllPath);
            if (!dllFileInfo.Exists)
            {
                _logger.Warn($"can not find file {dllFileInfo.FullName}");
                return null;
            }
            FileInfo pdbFileInfo = new FileInfo(pdbPath);
            if (!pdbFileInfo.Exists)
            {
                _logger.Warn($"can not find file {pdbFileInfo.FullName}");
                return null;
            }
            var dllBytes = File.ReadAllBytes(dllPath);
            var pdbBytes = File.ReadAllBytes(pdbPath);
            var assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }

        public static Assembly LoadAssembly(string path, string dllName)
        {
            //            byte[] dllBytes = File.ReadAllBytes("./Server.Module.dll");
            //            byte[] pdbBytes = File.ReadAllBytes("./Server.Module.pdb");
            var dllFile = Path.Combine(path, $"{dllName}{DLLSUFFIX}");
            var assembly = Assembly.LoadFrom(dllFile);
            return assembly;
        }


        public static ErrorCode CheckFileExist(string path, out FileInfo fileInfo)
        {
            //            byte[] dllBytes = File.ReadAllBytes("./Server.Module.dll");
            //            byte[] pdbBytes = File.ReadAllBytes("./Server.Module.pdb");
            var dllPath = Path.Combine(path, $"{DLLNAME}{DLLSUFFIX}");
            var pdbPath = Path.Combine(path, $"{DLLNAME}{PDBSUFFIX}");
            FileInfo dllFileInfo = new FileInfo(dllPath);
            if (!dllFileInfo.Exists)
            {
                fileInfo = dllFileInfo;
                return ErrorCode.DLLError;
            }
            FileInfo pdbFileInfo = new FileInfo(pdbPath);
            if (!pdbFileInfo.Exists)
            {
                fileInfo = pdbFileInfo;
                return ErrorCode.PDBError;
            }
            fileInfo = null;
            return ErrorCode.Success;
        }

        public static void SetLoadName(string assemblyName)
        {
            //这里的名字格式约定需与csproj中的OutputAssembly一致
            DLLNAME = $"Components_source";
        }
    }
}