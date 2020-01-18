public partial class SessionEntity 
{

    public Server.ServerKeyComponent serverKey { get { return (Server.ServerKeyComponent)GetComponent(SessionComponentsLookup.ServerKey); } }
    public bool hasServerKey { get { return HasComponent(SessionComponentsLookup.ServerKey); } }

    public void AddServerKey(int newKey)
    {
        var index = SessionComponentsLookup.ServerKey;
        var component = (Server.ServerKeyComponent)CreateComponent(index, typeof(Server.ServerKeyComponent));
        component.Key = newKey;
        AddComponent(index, component);
    }

    public void ReplaceServerKey(int newKey) 
    {
        var index = SessionComponentsLookup.ServerKey;
        var component = (Server.ServerKeyComponent)CreateComponent(index, typeof(Server.ServerKeyComponent));
        component.Key = newKey;
        ReplaceComponent(index, component);
    }

    public void RemoveServerKey() 
    {
        RemoveComponent(SessionComponentsLookup.ServerKey);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherServerKey;

    public static Entitas.Matcher.IMatcher<SessionEntity> ServerKey 
    {
        get 
        {
            if (_matcherServerKey == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.ServerKey);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherServerKey = matcher;
            }
            return _matcherServerKey;
        }
    }
}
