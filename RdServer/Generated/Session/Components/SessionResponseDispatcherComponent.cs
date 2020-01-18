public partial class SessionEntity 
{

    public Server.ResponseDispatcherComponent responseDispatcher { get { return (Server.ResponseDispatcherComponent)GetComponent(SessionComponentsLookup.ResponseDispatcher); } }
    public bool hasResponseDispatcher { get { return HasComponent(SessionComponentsLookup.ResponseDispatcher); } }

    public void AddResponseDispatcher(Rd.Networking.ResponseDispatcher newDispatcher)
    {
        var index = SessionComponentsLookup.ResponseDispatcher;
        var component = (Server.ResponseDispatcherComponent)CreateComponent(index, typeof(Server.ResponseDispatcherComponent));
        component.Dispatcher = newDispatcher;
        AddComponent(index, component);
    }

    public void ReplaceResponseDispatcher(Rd.Networking.ResponseDispatcher newDispatcher) 
    {
        var index = SessionComponentsLookup.ResponseDispatcher;
        var component = (Server.ResponseDispatcherComponent)CreateComponent(index, typeof(Server.ResponseDispatcherComponent));
        component.Dispatcher = newDispatcher;
        ReplaceComponent(index, component);
    }

    public void RemoveResponseDispatcher() 
    {
        RemoveComponent(SessionComponentsLookup.ResponseDispatcher);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherResponseDispatcher;

    public static Entitas.Matcher.IMatcher<SessionEntity> ResponseDispatcher 
    {
        get 
        {
            if (_matcherResponseDispatcher == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.ResponseDispatcher);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherResponseDispatcher = matcher;
            }
            return _matcherResponseDispatcher;
        }
    }
}
