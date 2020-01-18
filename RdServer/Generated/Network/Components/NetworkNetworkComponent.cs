public partial class NetworkEntity 
{

    public Server.NetworkComponent network { get { return (Server.NetworkComponent)GetComponent(NetworkComponentsLookup.Network); } }
    public bool hasNetwork { get { return HasComponent(NetworkComponentsLookup.Network); } }

    public void AddNetwork(Rd.Networking.NetworkType newNetworkType, Rd.Networking.IOCP.ChannelType newChannelType, Rd.Networking.SessionType newSessionType, System.Net.IPEndPoint newIpEndPoint)
    {
        var index = NetworkComponentsLookup.Network;
        var component = (Server.NetworkComponent)CreateComponent(index, typeof(Server.NetworkComponent));
        component.NetworkType = newNetworkType;
        component.ChannelType = newChannelType;
        component.SessionType = newSessionType;
        component.IpEndPoint = newIpEndPoint;
        AddComponent(index, component);
    }

    public void ReplaceNetwork(Rd.Networking.NetworkType newNetworkType, Rd.Networking.IOCP.ChannelType newChannelType, Rd.Networking.SessionType newSessionType, System.Net.IPEndPoint newIpEndPoint) 
    {
        var index = NetworkComponentsLookup.Network;
        var component = (Server.NetworkComponent)CreateComponent(index, typeof(Server.NetworkComponent));
        component.NetworkType = newNetworkType;
        component.ChannelType = newChannelType;
        component.SessionType = newSessionType;
        component.IpEndPoint = newIpEndPoint;
        ReplaceComponent(index, component);
    }

    public void RemoveNetwork() 
    {
        RemoveComponent(NetworkComponentsLookup.Network);
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherNetwork;

    public static Entitas.Matcher.IMatcher<NetworkEntity> Network 
    {
        get 
        {
            if (_matcherNetwork == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Network);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherNetwork = matcher;
            }
            return _matcherNetwork;
        }
    }
}
