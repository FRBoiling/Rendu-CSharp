public partial class NetworkEntity {

    static readonly Components.TcpComponent tcpComponent = new Components.TcpComponent();

    public bool isTcp {
        get { return HasComponent(NetworkComponentsLookup.Tcp); }
        set {
            if (value != isTcp) {
                var index = NetworkComponentsLookup.Tcp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : tcpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherTcp;

    public static Entitas.Matcher.IMatcher<NetworkEntity> Tcp 
    {
        get 
        {
            if (_matcherTcp == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Tcp);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherTcp = matcher;
            }
            return _matcherTcp;
        }
    }
}
