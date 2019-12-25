public partial class NetworkEntity 
{

    public Server.ServiceComponent service { get { return (Server.ServiceComponent)GetComponent(NetworkComponentsLookup.Service); } }
    public bool hasService { get { return HasComponent(NetworkComponentsLookup.Service); } }

    public void AddService(Server.NetworkType newProtocolType, Server.ChannelType newChannelType, Microsoft.IO.RecyclableMemoryStreamManager newMemoryStreamManager, System.Net.Sockets.SocketAsyncEventArgs newEventArgs, System.Collections.Generic.HashSet<long> newNeedStartSendChannel, System.Net.Sockets.Socket newSocket)
    {
        var index = NetworkComponentsLookup.Service;
        var component = (Server.ServiceComponent)CreateComponent(index, typeof(Server.ServiceComponent));
        component.ProtocolType = newProtocolType;
        component.ChannelType = newChannelType;
        component.MemoryStreamManager = newMemoryStreamManager;
        component.EventArgs = newEventArgs;
        component.NeedStartSendChannel = newNeedStartSendChannel;
        component.Socket = newSocket;
        AddComponent(index, component);
    }

    public void ReplaceService(Server.NetworkType newProtocolType, Server.ChannelType newChannelType, Microsoft.IO.RecyclableMemoryStreamManager newMemoryStreamManager, System.Net.Sockets.SocketAsyncEventArgs newEventArgs, System.Collections.Generic.HashSet<long> newNeedStartSendChannel, System.Net.Sockets.Socket newSocket) 
    {
        var index = NetworkComponentsLookup.Service;
        var component = (Server.ServiceComponent)CreateComponent(index, typeof(Server.ServiceComponent));
        component.ProtocolType = newProtocolType;
        component.ChannelType = newChannelType;
        component.MemoryStreamManager = newMemoryStreamManager;
        component.EventArgs = newEventArgs;
        component.NeedStartSendChannel = newNeedStartSendChannel;
        component.Socket = newSocket;
        ReplaceComponent(index, component);
    }

    public void RemoveService() 
    {
        RemoveComponent(NetworkComponentsLookup.Service);
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherService;

    public static Entitas.Matcher.IMatcher<NetworkEntity> Service 
    {
        get 
        {
            if (_matcherService == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Service);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherService = matcher;
            }
            return _matcherService;
        }
    }
}
