using Entitas.Matcher;
public sealed partial class ServerMatcher 
{

    static IMatcher<ServerEntity> _matcherServer;

    public static IMatcher<ServerEntity> Server 
    {
        get 
        {
            if (_matcherServer == null) 
            {
                var matcher = (Matcher<ServerEntity>)Matcher<ServerEntity>.AllOf(ServerComponentsLookup.Server);
                matcher.componentNames = ServerComponentsLookup.componentNames;
                _matcherServer = matcher;
            }
            return _matcherServer;
        }
    }
}
