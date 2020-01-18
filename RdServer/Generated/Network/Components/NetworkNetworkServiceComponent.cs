public partial class NetworkEntity 
{

    public Server.NetworkService networkService { get { return (Server.NetworkService)GetComponent(NetworkComponentsLookup.NetworkService); } }
    public bool hasNetworkService { get { return HasComponent(NetworkComponentsLookup.NetworkService); } }

    public void AddNetworkService(Rd.Networking.IOCP.AService newService)
    {
        var index = NetworkComponentsLookup.NetworkService;
        var component = (Server.NetworkService)CreateComponent(index, typeof(Server.NetworkService));
        component.Service = newService;
        AddComponent(index, component);
    }

    public void ReplaceNetworkService(Rd.Networking.IOCP.AService newService) 
    {
        var index = NetworkComponentsLookup.NetworkService;
        var component = (Server.NetworkService)CreateComponent(index, typeof(Server.NetworkService));
        component.Service = newService;
        ReplaceComponent(index, component);
    }

    public void RemoveNetworkService() 
    {
        RemoveComponent(NetworkComponentsLookup.NetworkService);
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherNetworkService;

    public static Entitas.Matcher.IMatcher<NetworkEntity> NetworkService 
    {
        get 
        {
            if (_matcherNetworkService == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.NetworkService);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherNetworkService = matcher;
            }
            return _matcherNetworkService;
        }
    }
}
