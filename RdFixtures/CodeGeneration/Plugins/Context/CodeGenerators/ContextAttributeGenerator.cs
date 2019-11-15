using System.IO;
using System.Linq;
using Rd.CodeGeneration;
using Rd.Plugins.Context.DataProviders;

namespace Rd.Plugins.Context.CodeGenerators
{
    public class ContextAttributeGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"using Entitas.Attributes;
public sealed class ${ContextName}Attribute : ContextAttribute
{
    public ${ContextName}Attribute() : base(""${ContextName}"") 
    {
    }
}
";

        public string name => "Context (Attribute)";
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
                contextName + "Attribute.cs",
                TEMPLATE.Replace(contextName),
                GetType().FullName
            );
        }
    }
}