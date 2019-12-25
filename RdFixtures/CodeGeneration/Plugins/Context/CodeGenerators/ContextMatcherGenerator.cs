using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Rd.Plugins
{
    public class ContextMatcherGenerator : ICodeGenerator
    {
        private const string TEMPLATE =
            @"using Entitas.Matcher;
public sealed partial class ${MatcherType}
{

    public static IAllOfMatcher<${EntityType}> AllOf(params int[] indices) 
    {
        return Matcher<${EntityType}>.AllOf(indices);
    }

    public static IAllOfMatcher<${EntityType}> AllOf(params IMatcher<${EntityType}>[] matchers) 
    {
          return Matcher<${EntityType}>.AllOf(matchers);
    }

    public static IAnyOfMatcher<${EntityType}> AnyOf(params int[] indices) 
    {
          return Matcher<${EntityType}>.AnyOf(indices);
    }

    public static IAnyOfMatcher<${EntityType}> AnyOf(params IMatcher<${EntityType}>[] matchers) 
    {
          return Matcher<${EntityType}>.AnyOf(matchers);
    }
}
";

        public string name => "Context (Matcher API)";
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
                contextName.AddMatcherSuffix() + ".cs",
                TEMPLATE.Replace(contextName),
                GetType().FullName
            );
        }
    }
}