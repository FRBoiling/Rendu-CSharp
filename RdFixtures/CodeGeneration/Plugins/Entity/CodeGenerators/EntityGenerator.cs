using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;
using Rd.Plugins.Context;
using Rd.Plugins.Context.DataProviders;

namespace Rd.Plugins.Entity.CodeGenerators
{
    public class EntityGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"using Entitas.Entity;
public sealed partial class ${EntityType} : Entity 
{
}
";

        public string name => "Entity";
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
                contextName.AddEntitySuffix() + ".cs",
                TEMPLATE.Replace(contextName),
                GetType().FullName
            );
        }
    }
}