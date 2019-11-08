using System.IO;
using Entitas.CodeGeneration.Plugins.Context;
using Entitas.CodeGeneration.Plugins.Context.DataProviders;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.Entity.CodeGenerators
{
    public class EntityGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"public sealed partial class ${EntityType} : Entitas.Entity {
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