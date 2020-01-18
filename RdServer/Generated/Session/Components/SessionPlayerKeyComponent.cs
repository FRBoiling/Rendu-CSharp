public partial class SessionEntity 
{

    public Server.PlayerKeyComponent playerKey { get { return (Server.PlayerKeyComponent)GetComponent(SessionComponentsLookup.PlayerKey); } }
    public bool hasPlayerKey { get { return HasComponent(SessionComponentsLookup.PlayerKey); } }

    public void AddPlayerKey(int newKey)
    {
        var index = SessionComponentsLookup.PlayerKey;
        var component = (Server.PlayerKeyComponent)CreateComponent(index, typeof(Server.PlayerKeyComponent));
        component.Key = newKey;
        AddComponent(index, component);
    }

    public void ReplacePlayerKey(int newKey) 
    {
        var index = SessionComponentsLookup.PlayerKey;
        var component = (Server.PlayerKeyComponent)CreateComponent(index, typeof(Server.PlayerKeyComponent));
        component.Key = newKey;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerKey() 
    {
        RemoveComponent(SessionComponentsLookup.PlayerKey);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherPlayerKey;

    public static Entitas.Matcher.IMatcher<SessionEntity> PlayerKey 
    {
        get 
        {
            if (_matcherPlayerKey == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.PlayerKey);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherPlayerKey = matcher;
            }
            return _matcherPlayerKey;
        }
    }
}
