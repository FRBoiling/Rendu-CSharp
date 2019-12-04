using Entitas.Matcher;
public sealed partial class NetworkMatcher 
{

    static IMatcher<NetworkEntity> _matcherComponentsTcp;

    public static IMatcher<NetworkEntity> ComponentsTcp 
    {
        get 
        {
            if (_matcherComponentsTcp == null) 
            {
                var matcher = (Matcher<NetworkEntity>)Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.ComponentsTcp);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherComponentsTcp = matcher;
            }
            return _matcherComponentsTcp;
        }
    }
}
