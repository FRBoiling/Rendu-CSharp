using Entitas;

[Context("Test")]
[Event(EventTarget.Any)]
public sealed class StandardEventComponent : IComponent
{
    public string value;
}