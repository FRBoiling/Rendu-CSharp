using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace TestProject.Fixtures
{
    [Context("Test1"), Context("Test2")]
    public sealed class TestStandardComponent : IComponent {
        public string value;
    }
    
    public sealed class TestNoContextComponent : IComponent {
        public string value;
    }
    
    [Context("Test1"),Unique]
    public sealed class TestUniqueContextComponent : IComponent {
        public string value;
    }
    
    [Context("Test1"),DontGenerate(false)]
    public sealed class TestDontGenerateIndexComponent : IComponent {
        public string value;
    }
    
    [Context("Test1"), Unique, FlagPrefix("My")]
    public sealed class TestCustomPrefixFlagComponent : IComponent {
    }
    
    [Context("Test1"), Event(EventTarget.Any)]
    public sealed class TestEventStandardComponent : IComponent {
        public string value;
    }
    
    [Context("Test"), Context("Test2"), Event(EventTarget.Any, EventType.Added, 1), Event(EventTarget.Self, EventType.Removed, 2)]
    public sealed class TestMultipleEventsStandardComponent : IComponent {
        public string value;
    }
    
    [Context("Test"), Event(EventTarget.Self, EventType.Removed, 1)]
    public sealed class TestEntityEventStandardComponent : IComponent {
        public string value;
    }

    [Context("Test"), Unique, Event(EventTarget.Any)]
    public sealed class TestUniqueEventComponent : IComponent {
        public string value;
    }
    
    [Context("Test"), Context("Test2"), Event(EventTarget.Any)]
    public sealed class TestMultipleContextStandardEventComponent : IComponent {
        public string value;
    }
    
    [Context("Test"), Context("Test2")]
    public sealed class NameAgeComponent : IComponent {

        public string name;
        public int age;

        public override string ToString() {
            return "NameAge(" + name + ", " + age + ")";
        }
    }
    
    [Context("Test"), Context("Test2")]
    public sealed class Test2ContextComponent : IComponent {
        public string value;
    }
    
    [Entitas.CodeGeneration.Attributes.DontGenerate(false)]
    public sealed class ClassToGenerateComponent : Entitas.IComponent {
        public TestClassToGenerate value;
    }
}