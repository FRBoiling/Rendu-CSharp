using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class TestContext : Context<TestEntity> 
{

    public TestContext()
        : base(
            TestComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Test",
                TestComponentsLookup.componentNames,
                TestComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new TestEntity()
        ) 
    {
    }
}
