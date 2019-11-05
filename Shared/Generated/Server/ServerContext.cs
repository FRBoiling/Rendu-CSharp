public sealed partial class ServerContext : Entitas.Context<ServerEntity> {

    public ServerContext()
        : base(
            ServerComponentsLookup.TotalComponents,
            0,
            new Entitas.ContextInfo(
                "Server",
                ServerComponentsLookup.componentNames,
                ServerComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                new Entitas.SafeAERC(entity),
#endif
            () => new ServerEntity()
        ) {
    }
}
