using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class SessionContext : Context<SessionEntity> 
{

    public SessionContext()
        : base(
            SessionComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Session",
                SessionComponentsLookup.componentNames,
                SessionComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new SessionEntity()
        ) 
    {
    }
}
