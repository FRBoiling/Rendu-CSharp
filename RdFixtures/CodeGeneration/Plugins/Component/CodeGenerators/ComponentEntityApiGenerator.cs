using System.IO;
using System.Linq;
using Entitas.Extensions;
using Rd.CodeGeneration;
using Rd.Utils;

namespace Rd.Plugins
{
    public class ComponentEntityApiGenerator : AbstractGenerator
    {
        private const string STANDARD_TEMPLATE =
            @"public partial class ${EntityType} 
{

    public ${ComponentType} ${validComponentName} { get { return (${ComponentType})GetComponent(${Index}); } }
    public bool has${ComponentName} { get { return HasComponent(${Index}); } }

    public void Add${ComponentName}(${newMethodParameters})
    {
        var index = ${Index};
        var component = (${ComponentType})CreateComponent(index, typeof(${ComponentType}));
${memberAssignmentList}
        AddComponent(index, component);
    }

    public void Replace${ComponentName}(${newMethodParameters}) 
    {
        var index = ${Index};
        var component = (${ComponentType})CreateComponent(index, typeof(${ComponentType}));
${memberAssignmentList}
        ReplaceComponent(index, component);
    }

    public void Remove${ComponentName}() 
    {
        RemoveComponent(${Index});
    }
}
";

        private const string FLAG_TEMPLATE =
            @"public partial class ${EntityType} {

    static readonly ${ComponentType} ${componentName}Component = new ${ComponentType}();

    public bool ${prefixedComponentName} {
        get { return HasComponent(${Index}); }
        set {
            if (value != ${prefixedComponentName}) {
                var index = ${Index};
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : ${componentName}Component;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
";

        public override string name => "Component (Entity API)";

        public override CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ComponentData>()
                .Where(d => d.ShouldGenerateMethods())
                .SelectMany(generate)
                .ToArray();
        }

        private CodeGenFile[] generate(ComponentData data)
        {
            return data.GetContextNames()
                .Select(contextName => generate(contextName, data))
                .ToArray();
        }

        private CodeGenFile generate(string contextName, ComponentData data)
        {
            var template = data.GetMemberData().Length == 0
                ? FLAG_TEMPLATE
                : STANDARD_TEMPLATE;

            var fileContent = template
                .Replace("${memberAssignmentList}", getMemberAssignmentList(data.GetMemberData()))
                .Replace(data, contextName);

            return new CodeGenFile(
                contextName + Path.DirectorySeparatorChar +
                "Components" + Path.DirectorySeparatorChar +
                data.ComponentNameWithContext(contextName).AddComponentSuffix() + ".cs",
                fileContent,
                GetType().FullName
            );
        }

        private string getMemberAssignmentList(MemberData[] memberData)
        {
            //return string.Join("\n", memberData
            //    .Select(info => "        component." + info.name + " = new" + info.name.UppercaseFirst() + ";")
            //    .ToArray()
            //);

            var str = string.Join("\n", memberData
                .Select(info => "        component." + info.name + " = new" + info.name.UppercaseFirst() + ";")
                .ToArray()
                );
            return str;
        }
    }
}