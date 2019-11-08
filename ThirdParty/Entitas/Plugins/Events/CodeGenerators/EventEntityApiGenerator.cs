using System.IO;
using Entitas.CodeGeneration.Plugins.Component;
using Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders;
using Entitas.Extensions;
using Rd.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins.Events.CodeGenerators
{
    public class EventEntityApiGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"public partial class ${EntityType} {

    public void Add${EventListener}(I${EventListener} value) {
        var listeners = has${EventListener}
            ? ${eventListener}.value
            : new System.Collections.Generic.List<I${EventListener}>();
        listeners.Add(value);
        Replace${EventListener}(listeners);
    }

    public void Remove${EventListener}(I${EventListener} value, bool removeComponentWhenEmpty = true) {
        var listeners = ${eventListener}.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            Remove${EventListener}();
        } else {
            Replace${EventListener}(listeners);
        }
    }
}
";

        public override string name => "Event (Entity API)";

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
                    contextName + Path.DirectorySeparatorChar +
                    "Components" + Path.DirectorySeparatorChar +
                    contextName + data.EventListener(contextName, eventData).AddComponentSuffix() + ".cs",
                    TEMPLATE.Replace(data, contextName, eventData),
                    GetType().FullName
                )).ToArray();
        }
    }
}