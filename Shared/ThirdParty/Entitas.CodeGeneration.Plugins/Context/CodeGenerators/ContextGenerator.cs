using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins
{
    public class ContextGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"public sealed partial class ${ContextType} : Entitas.Context<${EntityType}> {

    public ${ContextType}()
        : base(
            ${Lookup}.TotalComponents,
            0,
            new Entitas.ContextInfo(
                ""${ContextName}"",
                ${Lookup}.componentNames,
                ${Lookup}.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                new Entitas.SafeAERC(entity),
#endif
            () => new ${EntityType}()
        ) {
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