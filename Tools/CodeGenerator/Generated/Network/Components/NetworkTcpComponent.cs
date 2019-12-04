using Entitas.Matcher;
public sealed partial class NetworkMatcher 
{

    static IMatcher<NetworkEntity> _matcherTcp;

    public static IMatcher<NetworkEntity> Tcp 
    {
        get 
        {
            if (_matcherTcp == null) 
            {
                var matcher = (Matcher<NetworkEntity>)Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Tcp);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherTcp = matcher;
            }
            return _matcherTcp;
        }
    }
}
