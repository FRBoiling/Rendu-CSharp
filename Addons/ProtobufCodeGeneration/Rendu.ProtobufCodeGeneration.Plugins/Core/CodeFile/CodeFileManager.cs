using System;
using System.Collections.Generic;
using System.IO;
using Rd.Utils;

namespace Rendu.ProtobufCodeGeneration.Plugins
{
    public class CodeFileManager:Singleton<CodeFileManager>
    {
        //key :filename
        public readonly Dictionary<string, CodeFile> CodeFiles = new Dictionary<string, CodeFile>();
        
        private void AddCodeFile(CodeFile codeFile)
        {
            if (CodeFiles.ContainsKey(codeFile.Name))
            {
                return;
            }
            CodeFiles.Add(codeFile.Name,codeFile);
        }

        private void LoadFile(FileInfo fileInfo)
        {
            var parser = new CodeFileParser();
            try
            {
                var codeFile =  parser.ParserFile(fileInfo);
                if (codeFile == null)
                {
                    return;
                }

                AddCodeFile(codeFile);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void LoadFile(string fileFullName)
        {
             CodeFileParser parser = new CodeFileParser();
            if (fileFullName == null)
            {
                throw new Exception("ParseCodeFile error : fileFullName is null.");
            }

            try
            {
                CodeFile codeFile =  parser.ParserFile(fileFullName);

                if (codeFile == null)
                {
                    return;
                }

                AddCodeFile(codeFile);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void LoadFiles(string dir)
        {
           var files = FileUtil.FindFiles(dir, "*.code");
           if (files == null)
           {
                throw new Exception($"load file fail : check file dir {dir}");
           }
           foreach (var file in files)
           {
               LoadFile(file);
           }
        }


    }
}