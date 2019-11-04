public sealed partial class Test1Context : Entitas.Context<Test1Entity> {

    public Test1Context()
        : base(
            Test1ComponentsLookup.TotalComponents,
            0,
            new Entitas.ContextInfo(
                "Test1",
                Test1ComponentsLookup.componentNames,
                Test1ComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                new Entitas.SafeAERC(entity),
#endif
            () => new Test1Entity()
        ) {
    }
}
