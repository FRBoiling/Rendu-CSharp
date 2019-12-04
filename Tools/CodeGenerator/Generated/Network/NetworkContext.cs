using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class NetworkContext : Context<NetworkEntity> 
{

    public NetworkContext()
        : base(
            NetworkComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Network",
                NetworkComponentsLookup.componentNames,
                NetworkComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new NetworkEntity()
        ) 
    {
    }
}
