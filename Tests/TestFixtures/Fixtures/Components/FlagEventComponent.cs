using Entitas;

[Context("Test")]
[Event(EventTarget.Any, EventType.Removed)]
public sealed class FlagEventComponent : IComponent
{
}