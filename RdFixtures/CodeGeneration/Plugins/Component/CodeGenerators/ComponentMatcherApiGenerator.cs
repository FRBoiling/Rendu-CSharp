using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Rd.Plugins
{
    public class ComponentMatcherApiGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"
public sealed partial class ${MatcherType} 
{

    static Entitas.Matcher.IMatcher<${EntityType}> _matcher${ComponentName};

    public static Entitas.Matcher.IMatcher<${EntityType}> ${ComponentName} 
    {
        get 
        {
            if (_matcher${ComponentName} == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<${EntityType}>)Entitas.Matcher.Matcher<${EntityType}>.AllOf(${Index});
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