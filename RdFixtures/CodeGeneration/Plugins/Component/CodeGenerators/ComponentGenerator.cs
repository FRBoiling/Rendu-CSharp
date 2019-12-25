using System.IO;
using System.Linq;
using Rd.CodeGeneration;
using Rd.Utils;

namespace Rd.Plugins
{
    public class ComponentGenerator : ICodeGenerator
    {
        private const string COMPONENT_TEMPLATE =
            @"[Entitas.Attributes.DontGenerate(false)]
public sealed class ${FullComponentName} : Entitas.IComponent {
    public ${Type} value;
}
";

        public string name => "Component";
        public int priority => 0;
        public bool runInDryMode => true;

        public CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ComponentData>()
                .Where(d => d.ShouldGenerateComponent())
                .Select(generate)
                .ToArray();
        }

        private CodeGenFile generate(ComponentData data)
        {
            var fullComponentName = data.GetTypeName().RemoveDots();
            return new CodeGenFile
            (
                "Components" + Path.DirectorySeparatorChar +
                fullComponentName + ".cs",
                COMPONENT_TEMPLATE
                    .Replace("${FullComponentName}", fullComponentName)
                    .Replace("${Type}", data.GetObjectTypeName()),
                GetType().FullName
            );
        }
    }
}