using System;
using System.Collections.Generic;
using System.Linq;

namespace DesperateDevs.CodeGeneration.Plugins
{
    public class ConsoleWriteLinePostProcessor : IPostProcessor, ICodeGenerationPlugin
    {
        public string name
        {
            get
            {
                return "Console.WriteLine generated files";
            }
        }

        public int priority
        {
            get
            {
                return 200;
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
            Console.WriteLine(((IEnumerable<CodeGenFile>) files).Aggregate<CodeGenFile, string>(string.Empty, (Func<string, CodeGenFile, string>) ((acc, file) => acc + file.fileName + " - " + file.generatorName + "\n")));
            return files;
        }
    }
}