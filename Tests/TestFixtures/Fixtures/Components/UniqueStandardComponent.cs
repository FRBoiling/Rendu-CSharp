using Entitas;

[Context("Test")]
[Unique]
public sealed class UniqueStandardComponent : IComponent
{
    public string value;
}