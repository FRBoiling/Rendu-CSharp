using Entitas;

public sealed class ServerContext : Context<ServerEntity>
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
            entity =>
#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new ServerEntity()
        )
    {
    }
}