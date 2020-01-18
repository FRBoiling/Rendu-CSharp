public partial class SessionEntity {

    static readonly Server.DestoryComponent destoryComponent = new Server.DestoryComponent();

    public bool flagDestory {
        get { return HasComponent(SessionComponentsLookup.Destory); }
        set {
            if (value != flagDestory) {
                var index = SessionComponentsLookup.Destory;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destoryComponent;

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

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherDestory;

    public static Entitas.Matcher.IMatcher<SessionEntity> Destory 
    {
        get 
        {
            if (_matcherDestory == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.Destory);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherDestory = matcher;
            }
            return _matcherDestory;
        }
    }
}
