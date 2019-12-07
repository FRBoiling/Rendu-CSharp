using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class ZoneContext : Context<ZoneEntity> 
{

    public ZoneContext()
        : base(
            ZoneComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Zone",
                ZoneComponentsLookup.componentNames,
                ZoneComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new ZoneEntity()
        ) 
    {
    }
}
