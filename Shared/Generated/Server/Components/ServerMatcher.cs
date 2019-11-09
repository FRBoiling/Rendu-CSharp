using Entitas.Matcher;
using Entitas.Matcher.Interfaces;

namespace Generated.Server.Components
{
    public sealed partial class ServerMatcher
    {
        private static IMatcher<ServerEntity> _matcherServer;

        public static IMatcher<ServerEntity> Server
        {
            get
            {
                if (_matcherServer == null)
                {
                    var matcher = (Matcher<ServerEntity>) Matcher<ServerEntity>.AllOf(ServerComponentsLookup.Server);
                    matcher.componentNames = ServerComponentsLookup.componentNames;
                    _matcherServer = matcher;
                }

                return _matcherServer;
            }
        }
    }
}