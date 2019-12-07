using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class GateContext : Context<GateEntity> 
{

    public GateContext()
        : base(
            GateComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Gate",
                GateComponentsLookup.componentNames,
                GateComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new GateEntity()
        ) 
    {
    }
}
