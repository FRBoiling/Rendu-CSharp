using Entitas;

[Context("Test")]
[Context("Test2")]
[Event(EventTarget.Any)]
public sealed class MultipleContextStandardEventComponent : IComponent
{
    public string value;
}