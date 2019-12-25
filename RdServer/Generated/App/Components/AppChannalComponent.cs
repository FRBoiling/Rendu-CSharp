public partial class AppEntity 
{

    public Server.ChannalComponent channal { get { return (Server.ChannalComponent)GetComponent(AppComponentsLookup.Channal); } }
    public bool hasChannal { get { return HasComponent(AppComponentsLookup.Channal); } }

    public void AddChannal(System.Net.Sockets.Socket newSocket)
    {
        var index = AppComponentsLookup.Channal;
        var component = (Server.ChannalComponent)CreateComponent(index, typeof(Server.ChannalComponent));
        component.Socket = newSocket;
        AddComponent(index, component);
    }

    public void ReplaceChannal(System.Net.Sockets.Socket newSocket) 
    {
        var index = AppComponentsLookup.Channal;
        var component = (Server.ChannalComponent)CreateComponent(index, typeof(Server.ChannalComponent));
        component.Socket = newSocket;
        ReplaceComponent(index, component);
    }

    public void RemoveChannal() 
    {
        RemoveComponent(AppComponentsLookup.Channal);
    }
}


public sealed partial class AppMatcher 
{

    static Entitas.Matcher.IMatcher<AppEntity> _matcherChannal;

    public static Entitas.Matcher.IMatcher<AppEntity> Channal 
    {
        get 
        {
            if (_matcherChannal == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<AppEntity>)Entitas.Matcher.Matcher<AppEntity>.AllOf(AppComponentsLookup.Channal);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherChannal = matcher;
            }
            return _matcherChannal;
        }
    }
}
