using Entitas;

namespace My.Namespace
{
    public class EntityIndexNoContextComponent : IComponent
    {
        [EntityIndex] public string value;
    }
}