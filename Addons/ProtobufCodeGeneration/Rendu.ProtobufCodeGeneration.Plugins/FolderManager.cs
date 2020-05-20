using System;
using System.IO;
using Rd.Utils;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class FolderManager : Singleton<FolderManager>
    {
        public string CurrentDirectory = string.Empty;
        public string BinDirectory = string.Empty;

        public string GoogleGeneratorFileDirectory = string.Empty;

        public string ProtocolFileDirectory = string.Empty;

        public string CodeFilesDir = string.Empty;
        public string ProtoFilesDir = string.Empty;
        public string CSharpFilesDir = string.Empty;

        public void Init(string currentDirectory)
        {
            CurrentDirectory = currentDirectory;
            var curDirectoryInfo = new DirectoryInfo(CurrentDirectory);
            if (curDirectoryInfo.Parent != null)
            {
                BinDirectory = curDirectoryInfo.Parent.FullName;
            }
            else
            {
                throw new Exception($"please check bin directory:({currentDirectory})");
            }

        }

        public bool InitWorkFileDir(string inputDir)
        {
            CodeFilesDir = inputDir;
            var codeDirInfo = new DirectoryInfo(CodeFilesDir);
            if (codeDirInfo.Parent != null)
            {
                ProtocolFileDirectory = codeDirInfo.Parent.FullName;
            }
            else
            {
                throw new Exception($"please check protocol file directory folder:({inputDir})");
            }

            GoogleGeneratorFileDirectory = DirectoryUtil.PathCombine(CodeFilesDir, ConstData.PROTOC_DIR);
            ProtoFilesDir = DirectoryUtil.PathCombine(CodeFilesDir, ConstData.PROTO_FILE_FOLDER);
            CSharpFilesDir = DirectoryUtil.PathCombine(CodeFilesDir, ConstData.CSHARP_FILE_FOLDER);
            return true;
        }

        public void PrintAllDirs()
        {
            //Log.Debug("------------------------------");
            //Log.Debug($"{CurrentDirectory}");
            //Log.Debug("------------------------------");

            //Log.Debug($"{BinDirectory}");
            //Log.Debug($"{GoogleGeneratorFileDirectory}");
            //Log.Debug($"{ProtocolFileDirectory}");
            //Log.Debug($"{CodeFilesDir}");
            //Log.Debug($"{ProtoFilesDir}");
            //Log.Debug($"{CSharpFilesDir}");
        }
    }
}