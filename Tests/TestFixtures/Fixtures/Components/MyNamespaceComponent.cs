using Entitas;

namespace My.Namespace
{
    [Context("Test")]
    [Context("Test2")]
    public sealed class MyNamespaceComponent : IComponent
    {
        public string value;
    }
}