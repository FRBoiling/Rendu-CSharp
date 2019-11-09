using Entitas;
using Entitas.Context;
using Entitas.Entity;

namespace TestFixtures.Generated.Test1
{
    public sealed class Test1Context : Context<Test1Entity>
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
                entity =>
#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                    new SafeAERC(entity),
#endif
                () => new Test1Entity()
            )
        {
        }
    }
}