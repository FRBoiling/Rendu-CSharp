using Entitas;

[Context("Test")]
[Event(EventTarget.Self, EventType.Removed, 1)]
public sealed class StandardEntityEventComponent : IComponent
{
    public string value;
}