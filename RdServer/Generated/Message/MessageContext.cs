using Entitas;
using Entitas.Context;
using Entitas.Entity;

public sealed partial class MessageContext : Context<MessageEntity> 
{

    public MessageContext()
        : base(
            MessageComponentsLookup.TotalComponents,
            0,
            new ContextInfo(
                "Message",
                MessageComponentsLookup.componentNames,
                MessageComponentsLookup.componentTypes
            ),
            (entity) =>

#if (ENTITAS_FAST_AND_UNSAFE)
                new UnsafeAERC(),
#else
                new SafeAERC(entity),
#endif
            () => new MessageEntity()
        ) 
    {
    }
}
