public sealed partial class NetworkContext : Entitas.Context<NetworkEntity> {

    public NetworkContext()
        : base(
            NetworkComponentsLookup.TotalComponents,
            0,
            new Entitas.ContextInfo(
                "Network",
                NetworkComponentsLookup.componentNames,
                NetworkComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new Entitas.UnsafeAERC(),
#else
                new Entitas.SafeAERC(entity),
#endif
            () => new NetworkEntity()
        ) {
    }
}
