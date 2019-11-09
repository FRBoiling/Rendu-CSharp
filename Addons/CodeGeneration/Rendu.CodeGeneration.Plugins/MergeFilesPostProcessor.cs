using System;
using System.Collections.Generic;
using System.Linq;
using Rd.CodeGeneration;

namespace Rendu.CodeGeneration.Plugins
{
    public class MergeFilesPostProcessor : IPostProcessor, ICodeGenerationPlugin
    {
        public string name
        {
            get
            {
                return "Merge files";
            }
        }

        public int priority
        {
            get
            {
                return 90;
            }
        }

        public bool runInDryMode
        {
            get
            {
                return true;
            }
        }

        public CodeGenFile[] PostProcess(CodeGenFile[] files)
        {
            Dictionary<string, CodeGenFile> dictionary = new Dictionary<string, CodeGenFile>();
            for (int index = 0; index < files.Length; ++index)
            {
                CodeGenFile file = files[index];
                if (!dictionary.ContainsKey(file.fileName))
                {
                    dictionary.Add(file.fileName, file);
                }
                else
                {
                    CodeGenFile codeGenFile1 = dictionary[file.fileName];
                    codeGenFile1.fileContent = codeGenFile1.fileContent + "\n" + file.fileContent;
                    CodeGenFile codeGenFile2 = dictionary[file.fileName];
                    codeGenFile2.generatorName = codeGenFile2.generatorName + ", " + file.generatorName;
                    files[index] = (CodeGenFile) null;
                }
            }
            return ((IEnumerable<CodeGenFile>) files).Where<CodeGenFile>((Func<CodeGenFile, bool>) (file => file != null)).ToArray<CodeGenFile>();
        }
    }
}