using System;
using Rd.CodeGeneration;

namespace Rendu.CodeGeneration.Plugins
{
    public class NewLinePostProcessor : IPostProcessor, ICodeGenerationPlugin
    {
        public string name
        {
            get
            {
                return "Convert newlines";
            }
        }

        public int priority
        {
            get
            {
                return 95;
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
            foreach (CodeGenFile file in files)
                file.fileContent = file.fileContent.Replace("\n", Environment.NewLine);
            return files;
        }
    }
}