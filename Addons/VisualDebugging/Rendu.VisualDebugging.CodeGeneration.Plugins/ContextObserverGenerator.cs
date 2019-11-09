using System;
using System.Collections.Generic;
using System.Linq;
using Rd.CodeGeneration;
using Rd.Plugins.Context;
using Rd.Plugins.Context.DataProviders;
using Rd.Utils;

namespace Rendu.VisualDebugging.CodeGeneration.Plugins
{
    public class ContextObserverGenerator : ICodeGenerator
    {
        private const string CONTEXTS_TEMPLATE =
            "public partial class Contexts {\n\n#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)\n\n    [Entitas.CodeGeneration.Entitas.Attributes.PostConstructor]\n    public void InitializeContextObservers() {\n        try {\n${contextObservers}\n        } catch(System.Exception) {\n        }\n    }\n\n    public void CreateContextObserver(Entitas.IContext context) {\n        if (UnityEngine.Application.isPlaying) {\n            var observer = new Rendu.VisualDebugging.Unity.ContextObserver(context);\n            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);\n        }\n    }\n\n#endif\n}\n";

        private const string CONTEXT_OBSERVER_TEMPLATE = "            CreateContextObserver(${contextName});";

        public string name
        {
            get { return "Context Observer"; }
        }

        public int priority
        {
            get { return 0; }
        }

        public bool runInDryMode
        {
            get { return true; }
        }

        public CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return new CodeGenFile[1]
            {
                new CodeGenFile("Contexts.cs",
                    this.generateContextsClass(data.OfType<ContextData>().Select<ContextData, string>((Func<ContextData, string>) (d => d.GetContextName()))
                        .OrderBy<string, string>((Func<string, string>) (contextName => contextName)).ToArray<string>()), this.GetType().FullName)
            };
        }

        private string generateContextsClass(string[] contextNames)
        {
            return
                "public partial class Contexts {\n\n#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)\n\n    [Entitas.CodeGeneration.Entitas.Attributes.PostConstructor]\n    public void InitializeContextObservers() {\n        try {\n${contextObservers}\n        } catch(System.Exception) {\n        }\n    }\n\n    public void CreateContextObserver(Entitas.IContext context) {\n        if (UnityEngine.Application.isPlaying) {\n            var observer = new Rendu.VisualDebugging.Unity.ContextObserver(context);\n            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);\n        }\n    }\n\n#endif\n}\n"
                    .Replace("${contextObservers}",
                        string.Join("\n",
                            ((IEnumerable<string>) contextNames).Select<string, string>((Func<string, string>) (contextName =>
                                "            CreateContextObserver(${contextName});".Replace("${contextName}", contextName.LowercaseFirst()))).ToArray<string>()));
        }
    }
}