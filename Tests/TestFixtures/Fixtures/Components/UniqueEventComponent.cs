using Entitas;

[Context("Test")]
[Unique]
[Event(EventTarget.Any)]
public sealed class UniqueEventComponent : IComponent
{
    public string value;
}