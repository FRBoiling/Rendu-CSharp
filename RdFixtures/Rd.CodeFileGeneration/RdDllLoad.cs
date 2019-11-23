using Rd.Logging;
using System.IO;
using System.Reflection;

namespace RDGenerationLib
{
    public class RdDllLoad
    {
        public enum ErrorCode
        {
            Success,
            DLLError,
            PDBError,
        }
        private readonly static Logger _logger = fabl.GetLogger(typeof (RdDllLoad));
        public const string DLLNAME = "Components";
        public const string DLLSUFFIX = ".dll";
        public const string PDBSUFFIX = ".pdb";
        public static Assembly GetComponentsAssembly(string path, string dllName)
        {
//            byte[] dllBytes = File.ReadAllBytes("./Server.Module.dll");
//            byte[] pdbBytes = File.ReadAllBytes("./Server.Module.pdb");
            var dllPath = Path.Combine(path, $"{dllName}{DLLSUFFIX}");
            var pdbPath = Path.Combine(path, $"{dllName}{PDBSUFFIX}");
            FileInfo dllFileInfo = new FileInfo(dllPath);
            if (!dllFileInfo.Exists)
            {
                _logger.Warn($"can not find file {dllFileInfo.FullName}");
                return Assembly.GetExecutingAssembly();
            }
            FileInfo pdbFileInfo = new FileInfo(pdbPath);
            if (!pdbFileInfo.Exists)
            {
                _logger.Warn($"can not find file {pdbFileInfo.FullName}");
                return Assembly.GetExecutingAssembly();
            }
            var dllBytes = File.ReadAllBytes(dllPath);
            var pdbBytes = File.ReadAllBytes(pdbPath);
            var assembly = Assembly.Load(dllBytes, pdbBytes);
            return assembly;
        }

        public static ErrorCode CheckFileExist(string path,out FileInfo fileInfo)
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




    }
}