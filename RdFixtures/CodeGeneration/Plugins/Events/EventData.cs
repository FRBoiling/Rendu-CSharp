using Entitas.Attributes;

namespace Rd.Plugins
{
    public class EventData
    {
        public readonly EventTarget eventTarget;
        public readonly EventType eventType;
        public readonly int priority;

        public EventData(EventTarget eventTarget, EventType eventType, int priority)
        {
            this.eventTarget = eventTarget;
            this.eventType = eventType;
            this.priority = priority;
        }
    }
}