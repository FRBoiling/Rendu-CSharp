using Entitas;

[Context("Test")]
[Event(EventTarget.Self, EventType.Added, 1)]
public sealed class FlagEntityEventComponent : IComponent
{
}