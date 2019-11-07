using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DesperateDevs.CodeGeneration.Unity.Plugins
{
    public class DebugLogPostProcessor : IPostProcessor, ICodeGenerationPlugin
    {
        public string name
        {
            get
            {
                return "Debug.Log generated files";
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
            Debug.Log((object)((IEnumerable<CodeGenFile>)files).Aggregate<CodeGenFile, string>(string.Empty, (Func<string, CodeGenFile, string>)((acc, file) => acc + file.fileName + " - " + file.generatorName + "\n")));
            return files;
        }
    }
}