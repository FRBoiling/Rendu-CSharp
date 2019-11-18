using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class ServerContext : Context<ServerEntity> 
{

    public ServerContext()
        : base(
            ServerComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Server",
                ServerComponentsLookup.componentNames,
                ServerComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new ServerEntity()
        ) 
    {
    }
}
