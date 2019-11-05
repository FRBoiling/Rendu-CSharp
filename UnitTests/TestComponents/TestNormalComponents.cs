using Entitas;
using Entitas.CodeGeneration.Attributes;

[Context("Test1")]
[Context("Test2")]
public sealed class TestNormalComponent : IComponent
{
    public string value;
}