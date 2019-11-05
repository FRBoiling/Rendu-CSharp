using Entitas.CodeGeneration.Attributes;

namespace TestProject.Fixtures
{
    [Context("Test1")]
    [Context("Test2")]
    public sealed class TestClassToGenerate
    {
        public string value;
    }

    [Context("Test")]
    [Context("Test2")]
    [Event(EventTarget.Any)]
    public sealed class TestEventClassToGenerate
    {
        public string value;
    }
}