using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class Test1Context : Context<Test1Entity> 
{

    public Test1Context()
        : base(
            Test1ComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Test1",
                Test1ComponentsLookup.componentNames,
                Test1ComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new Test1Entity()
        ) 
    {
    }
}
