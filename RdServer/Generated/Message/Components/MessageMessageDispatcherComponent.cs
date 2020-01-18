public partial class MessageEntity 
{

    public Server.Components.MessageDispatcherComponent messageDispatcher { get { return (Server.Components.MessageDispatcherComponent)GetComponent(MessageComponentsLookup.MessageDispatcher); } }
    public bool hasMessageDispatcher { get { return HasComponent(MessageComponentsLookup.MessageDispatcher); } }

    public void AddMessageDispatcher(Rd.Networking.IMessageDispatcher newDispatcher)
    {
        var index = MessageComponentsLookup.MessageDispatcher;
        var component = (Server.Components.MessageDispatcherComponent)CreateComponent(index, typeof(Server.Components.MessageDispatcherComponent));
        component.Dispatcher = newDispatcher;
        AddComponent(index, component);
    }

    public void ReplaceMessageDispatcher(Rd.Networking.IMessageDispatcher newDispatcher) 
    {
        var index = MessageComponentsLookup.MessageDispatcher;
        var component = (Server.Components.MessageDispatcherComponent)CreateComponent(index, typeof(Server.Components.MessageDispatcherComponent));
        component.Dispatcher = newDispatcher;
        ReplaceComponent(index, component);
    }

    public void RemoveMessageDispatcher() 
    {
        RemoveComponent(MessageComponentsLookup.MessageDispatcher);
    }
}


public sealed partial class MessageMatcher 
{

    static Entitas.Matcher.IMatcher<MessageEntity> _matcherMessageDispatcher;

    public static Entitas.Matcher.IMatcher<MessageEntity> MessageDispatcher 
    {
        get 
        {
            if (_matcherMessageDispatcher == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<MessageEntity>)Entitas.Matcher.Matcher<MessageEntity>.AllOf(MessageComponentsLookup.MessageDispatcher);
                matcher.componentNames = MessageComponentsLookup.componentNames;
                _matcherMessageDispatcher = matcher;
            }
            return _matcherMessageDispatcher;
        }
    }
}
