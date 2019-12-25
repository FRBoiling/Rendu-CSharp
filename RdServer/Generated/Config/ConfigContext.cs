using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class ConfigContext : Context<ConfigEntity> 
{

    public ConfigContext()
        : base(
            ConfigComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Config",
                ConfigComponentsLookup.componentNames,
                ConfigComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new ConfigEntity()
        ) 
    {
    }
}
