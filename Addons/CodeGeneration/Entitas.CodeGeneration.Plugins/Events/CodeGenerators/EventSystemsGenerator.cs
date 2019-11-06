using System.Collections.Generic;
using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;

namespace Entitas.CodeGeneration.Plugins
{
    public class EventSystemsGenerator : AbstractGenerator
    {
        private const string TEMPLATE =
            @"public sealed class ${ContextName}EventSystems : Feature {

    public ${ContextName}EventSystems(Contexts contexts) {
${systemsList}
    }
}
";

        private const string SYSTEM_ADD_TEMPLATE = @"        Add(new ${Event}EventSystem(contexts)); // priority: ${priority}";

        public override string name => "Event (Server.Systems)";

        public override CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return generate(data
                .OfType<ComponentData>()
                .Where(d => d.IsEvent())
                .ToArray());
        }

        private CodeGenFile[] generate(ComponentData[] data)
        {
            var contextNameToComponentData = data
                .Aggregate(new Dictionary<string, List<ComponentData>>(), (dict, d) =>
                {
                    var contextNames = d.GetContextNames();
                    foreach (var contextName in contextNames)
                    {
                        if (!dict.ContainsKey(contextName)) dict.Add(contextName, new List<ComponentData>());

                        dict[contextName].Add(d);
                    }

                    return dict;
                });

            var contextNameToDataTuple = new Dictionary<string, List<DataTuple>>();
            foreach (var key in contextNameToComponentData.Keys.ToArray())
            {
                var orderedEventData = contextNameToComponentData[key]
                    .SelectMany(d => d.GetEventData().Select(eventData => new DataTuple {componentData = d, eventData = eventData}).ToArray())
                    .OrderBy(tuple => tuple.eventData.priority)
                    .ThenBy(tuple => tuple.componentData.ComponentName())
                    .ToList();

                contextNameToDataTuple.Add(key, orderedEventData);
            }

            return generate(contextNameToDataTuple);
        }

        private CodeGenFile[] generate(Dictionary<string, List<DataTuple>> contextNameToDataTuple)
        {
            return contextNameToDataTuple
                .Select(kv => generateSystem(kv.Key, kv.Value.ToArray()))
                .ToArray();
        }

        private CodeGenFile generateSystem(string contextName, DataTuple[] data)
        {
            var fileContent = TEMPLATE
                .Replace("${systemsList}", generateSystemList(contextName, data))
                .Replace(contextName);

            return new CodeGenFile(
                "Events" + Path.DirectorySeparatorChar +
                contextName + "EventSystems.cs",
                fileContent,
                GetType().FullName
            );
        }

        private string generateSystemList(string contextName, DataTuple[] data)
        {
            return string.Join("\n", data
                .SelectMany(tuple => generateSystemListForData(contextName, tuple))
                .ToArray());
        }

        private string[] generateSystemListForData(string contextName, DataTuple data)
        {
            return data.componentData.GetContextNames()
                .Where(ctxName => ctxName == contextName)
                .Select(ctxName => generateAddSystem(ctxName, data))
                .ToArray();
        }

        private string generateAddSystem(string contextName, DataTuple data)
        {
            return SYSTEM_ADD_TEMPLATE
                .Replace(data.componentData, contextName, data.eventData)
                .Replace("${priority}", data.eventData.priority.ToString())
                .Replace("${Event}", data.componentData.Event(contextName, data.eventData));
        }

        private struct DataTuple
        {
            public ComponentData componentData;
            public EventData eventData;
        }
    }
}