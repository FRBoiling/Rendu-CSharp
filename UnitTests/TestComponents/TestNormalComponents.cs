using Entitas;
using Entitas.Attributes;

namespace TestComponents
{
    [Context("Test1")]
    [Context("Test2")]
    public sealed class TestNormalComponent : IComponent
    {
        public string value;
    }
}