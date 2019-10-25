using Entitas;

namespace My.Namespace
{
    [Context("Test")]
    [Unique]
    public sealed class UniqueMyNamespaceComponent : IComponent
    {
        public string value;
    }
}