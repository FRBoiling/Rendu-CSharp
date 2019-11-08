using System.IO;
using Entitas.CodeGeneration.Plugins.Component;
using Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders;
using Entitas.CodeGeneration.Plugins.Data;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.Events.CodeGenerators
{
    public class EventListenertInterfaceGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"public interface I${EventListener} {
    void On${EventComponentName}${EventType}(${ContextName}Entity entity${methodParameters});
}
";

        public override string name => "Event (Listener Interface)";

        public override CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ComponentData>()
                .Where(d => d.IsEvent())
                .SelectMany(generate)
                .ToArray();
        }

        private CodeGenFile[] generate(ComponentData data)
        {
            return data.GetContextNames()
                .SelectMany(contextName => generate(contextName, data))
                .ToArray();
        }

        private CodeGenFile[] generate(string contextName, ComponentData data)
        {
            return data.GetEventData()
                .Select(eventData =>
                {
                    var memberData = data.GetMemberData();
                    if (memberData.Length == 0) memberData = new[] {new MemberData("bool", data.PrefixedComponentName())};

                    var fileContent = TEMPLATE
                        .Replace("${methodParameters}", data.GetEventMethodArgs(eventData, ", " + memberData.GetMethodParameters(false)))
                        .Replace(data, contextName, eventData);

                    return new CodeGenFile(
                        "Events" + Path.DirectorySeparatorChar +
                        "Interfaces" + Path.DirectorySeparatorChar +
                        "I" + data.EventListener(contextName, eventData) + ".cs",
                        fileContent,
                        GetType().FullName
                    );
                }).ToArray();
        }
    }
}