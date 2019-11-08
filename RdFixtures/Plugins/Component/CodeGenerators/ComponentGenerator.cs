using System.IO;
using Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.Component.CodeGenerators
{
    public class ComponentGenerator : ICodeGenerator
    {
        private const string COMPONENT_TEMPLATE =
            @"[Entitas.CodeGeneration.Entitas.Attributes.DontGenerate(false)]
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