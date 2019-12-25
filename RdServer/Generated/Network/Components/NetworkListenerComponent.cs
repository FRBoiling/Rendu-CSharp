public partial class NetworkEntity 
{

    public Server.ListenerComponent listener { get { return (Server.ListenerComponent)GetComponent(NetworkComponentsLookup.Listener); } }
    public bool hasListener { get { return HasComponent(NetworkComponentsLookup.Listener); } }

    public void AddListener(System.Net.IPEndPoint newLocalEndPoint, bool newRelisten)
    {
        var index = NetworkComponentsLookup.Listener;
        var component = (Server.ListenerComponent)CreateComponent(index, typeof(Server.ListenerComponent));
        component.LocalEndPoint = newLocalEndPoint;
        component.Relisten = newRelisten;
        AddComponent(index, component);
    }

    public void ReplaceListener(System.Net.IPEndPoint newLocalEndPoint, bool newRelisten) 
    {
        var index = NetworkComponentsLookup.Listener;
        var component = (Server.ListenerComponent)CreateComponent(index, typeof(Server.ListenerComponent));
        component.LocalEndPoint = newLocalEndPoint;
        component.Relisten = newRelisten;
        ReplaceComponent(index, component);
    }

    public void RemoveListener() 
    {
        RemoveComponent(NetworkComponentsLookup.Listener);
    }
}


public sealed partial class NetworkMatcher 
{

    static Entitas.Matcher.IMatcher<NetworkEntity> _matcherListener;

    public static Entitas.Matcher.IMatcher<NetworkEntity> Listener 
    {
        get 
        {
            if (_matcherListener == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<NetworkEntity>)Entitas.Matcher.Matcher<NetworkEntity>.AllOf(NetworkComponentsLookup.Listener);
                matcher.componentNames = NetworkComponentsLookup.componentNames;
                _matcherListener = matcher;
            }
            return _matcherListener;
        }
    }
}
