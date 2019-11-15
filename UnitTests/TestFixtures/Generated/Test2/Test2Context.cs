using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class Test2Context : Context<Test2Entity> 
{

    public Test2Context()
        : base(
            Test2ComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Test2",
                Test2ComponentsLookup.componentNames,
                Test2ComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new Test2Entity()
        ) 
    {
    }
}
