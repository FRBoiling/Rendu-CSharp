using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Rd.Plugins
{
    public class ContextGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class ${ContextType} : Context<${EntityType}> 
{

    public ${ContextType}()
        : base(
            ${Lookup}.TotalComponents,
            0,
            new ContextInfo(
                ""${ContextName}"",
                ${Lookup}.componentNames,
                ${Lookup}.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new ${EntityType}()
        ) 
    {
    }
}
";

        public string name => "Context";
        public int priority => 0;
        public bool runInDryMode => true;

        public CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ContextData>()
                .Select(generate)
                .ToArray();
        }

        private CodeGenFile generate(ContextData data)
        {
            var contextName = data.GetContextName();
            return new CodeGenFile(
                contextName + Path.DirectorySeparatorChar +
                contextName.AddContextSuffix() + ".cs",
                TEMPLATE.Replace(contextName),
                GetType().FullName
            );
        }
    }
}