public partial class NetworkEntity 
{

    public Server.ConnectorComponent connector { get { return (Server.ConnectorComponent)GetComponent(NetworkComponentsLookup.Connector); } }
    public bool hasConnector { get { return HasComponent(NetworkComponentsLookup.Connector); } }

    public void AddConnector(System.Net.IPEndPoint newRemoteEndPoint, bool newReconnect)
    {
        var index = NetworkComponentsLookup.Connector;
        var component = (Server.ConnectorComponent)CreateComponent(index, typeof(Server.ConnectorComponent));
        component.RemoteEndPoint = newRemoteEndPoint;
        component.Reconnect = newReconnect;
        AddComponent(index, component);
    }

    public void ReplaceConnector(System.Net.IPEndPoint newRemoteEndPoint, bool newReconnect) 
    {
        var index = NetworkComponentsLookup.Connector;
        var component = (Server.ConnectorComponent)CreateComponent(index, typeof(Server.ConnectorComponent));
        component.RemoteEndPoint = newRemoteEndPoint;
        component.Reconnect = newReconnect;
        ReplaceComponent(index, component);
    }

    public void RemoveConnector() 
    {
        RemoveComponent(NetworkComponentsLookup.Connector);
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherConnector;

    public static Entitas.Matcher.IMatcher<NetworkEntity> Connector 
    {
        get 
        {
            if (_matcherConnector == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Connector);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherConnector = matcher;
            }
            return _matcherConnector;
        }
    }
}
