public partial class SessionEntity {

    static readonly Server.OfflineComponent offlineComponent = new Server.OfflineComponent();

    public bool isOffline {
        get { return HasComponent(SessionComponentsLookup.Offline); }
        set {
            if (value != isOffline) {
                var index = SessionComponentsLookup.Offline;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : offlineComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherOffline;

    public static Entitas.Matcher.IMatcher<SessionEntity> Offline 
    {
        get 
        {
            if (_matcherOffline == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.Offline);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherOffline = matcher;
            }
            return _matcherOffline;
        }
    }
}
