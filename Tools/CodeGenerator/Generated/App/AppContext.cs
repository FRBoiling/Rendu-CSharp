using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class AppContext : Context<AppEntity> 
{

    public AppContext()
        : base(
            AppComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "App",
                AppComponentsLookup.componentNames,
                AppComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new AppEntity()
        ) 
    {
    }
}
