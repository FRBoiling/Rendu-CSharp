using Entitas;
using Entitas.CodeGeneration.Attributes;

[Context("Game")]
public class DebugMessageComponent : IComponent
{
    // 属性数据
    public string message;
}