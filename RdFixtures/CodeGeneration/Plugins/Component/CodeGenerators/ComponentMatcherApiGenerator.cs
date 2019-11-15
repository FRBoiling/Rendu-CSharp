using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;
using Rd.Plugins.Component.DataProviders.ComponentDataProviders;

namespace Rd.Plugins.Component.CodeGenerators
{
    public class ComponentMatcherApiGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"using Entitas.Matcher;
public sealed partial class ${MatcherType} 
{

    static IMatcher<${EntityType}> _matcher${ComponentName};

    public static IMatcher<${EntityType}> ${ComponentName} 
    {
        get 
        {
            if (_matcher${ComponentName} == null) 
            {
                var matcher = (Matcher<${EntityType}>)Matcher<${EntityType}>.AllOf(${Index});
                matcher.componentNames = ${componentNames};
                _matcher${ComponentName} = matcher;
            }
            return _matcher${ComponentName};
        }
    }
}
";

        public override string name => "Component (Matcher API)";

        public override CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ComponentData>()
                .Where(d => d.ShouldGenerateIndex())
                .SelectMany(generate)
                .ToArray();
        }

        private CodeGenFile[] generate(ComponentData data)
        {
            return data.GetContextNames()
                .Select(context => generate(context, data))
                .ToArray();
        }

        private CodeGenFile generate(string contextName, ComponentData data)
        {
            var fileContent = TEMPLATE
                .Replace("${componentNames}", contextName + CodeGeneratorExtentions.LOOKUP + ".componentNames")
                .Replace(data, contextName);

            return new CodeGenFile(
                contextName + Path.DirectorySeparatorChar +
                "Components" + Path.DirectorySeparatorChar +
                data.ComponentNameWithContext(contextName).AddComponentSuffix() + ".cs",
                fileContent,
                GetType().FullName
            );
        }
    }
}