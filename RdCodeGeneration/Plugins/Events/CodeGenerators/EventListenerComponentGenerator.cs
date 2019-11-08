using System.IO;
using Entitas.CodeGeneration.Plugins.Component;
using Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.Events.CodeGenerators
{
    public class EventListenerComponentGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"[Entitas.CodeGeneration.Entitas.Attributes.DontGenerate(false)]
public sealed class ${EventListenerComponent} : Entitas.IComponent {
    public System.Collections.Generic.List<I${EventListener}> value;
}
";

        public override string name => "Event (Listener Component)";

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
                .Select(eventData => new CodeGenFile(
                    "Events" + Path.DirectorySeparatorChar +
                    "Components" + Path.DirectorySeparatorChar +
                    data.EventListener(contextName, eventData).AddComponentSuffix() + ".cs",
                    TEMPLATE.Replace(data, contextName, eventData),
                    GetType().FullName
                )).ToArray();
        }
    }
}