using Entitas;
using Entitas.CodeGeneration.Attributes;
using TestProject.Fixtures;

//[Test1]
public sealed class TestStandardComponent : IComponent
{
    public string value;
}

public sealed class TestNoContextComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Unique]
public sealed class TestUniqueContextComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[DontGenerate(false)]
public sealed class TestDontGenerateIndexComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Unique]
[FlagPrefix("My")]
public sealed class TestCustomPrefixFlagComponent : IComponent
{
}

[Context("Test1")]
[Event(EventTarget.Any)]
public sealed class TestEventStandardComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Context("Test2")]
[Event(EventTarget.Any, EventType.Added, 1)]
[Event(EventTarget.Self, EventType.Removed, 2)]
public sealed class TestMultipleEventsStandardComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Event(EventTarget.Self, EventType.Removed, 1)]
public sealed class TestEntityEventStandardComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Unique]
[Event(EventTarget.Any)]
public sealed class TestUniqueEventComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Context("Test2")]
[Event(EventTarget.Any)]
public sealed class TestMultipleContextStandardEventComponent : IComponent
{
    public string value;
}

[Context("Test1")]
[Context("Test2")]
public sealed class NameAgeComponent : IComponent
{
    public int age;
    public string name;

    public override string ToString()
    {
        return "NameAge(" + name + ", " + age + ")";
    }
}

[Context("Test1")]
[Context("Test2")]
public sealed class Test2ContextComponent : IComponent
{
    public string value;
}

[DontGenerate(false)]
public sealed class ClassToGenerateComponent : IComponent
{
    public TestClassToGenerate value;
}