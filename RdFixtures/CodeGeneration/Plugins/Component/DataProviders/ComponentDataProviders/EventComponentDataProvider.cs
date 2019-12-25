using System;
using System.Linq;
using Entitas.Attributes;
using Rd.Plugins;

namespace Rd.Plugins
{
    public class EventComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var attrs = Attribute.GetCustomAttributes(type)
                .OfType<EventAttribute>()
                .ToArray();

            if (attrs.Length > 0)
            {
                data.IsEvent(true);
                var eventData = attrs
                    .Select(attr => new EventData(attr.eventTarget, attr.eventType, attr.priority))
                    .ToArray();

                data.SetEventData(eventData);
            }
            else
            {
                data.IsEvent(false);
            }
        }
    }
}