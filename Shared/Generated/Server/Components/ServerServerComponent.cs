public sealed partial class ServerMatcher {

    static Entitas.IMatcher<ServerEntity> _matcherServer;

    public static Entitas.IMatcher<ServerEntity> Server {
        get {
            if (_matcherServer == null) {
                var matcher = (Entitas.Matcher<ServerEntity>)Entitas.Matcher<ServerEntity>.AllOf(ServerComponentsLookup.Server);
                matcher.componentNames = ServerComponentsLookup.componentNames;
                _matcherServer = matcher;
            }

            return _matcherServer;
        }
    }
}
