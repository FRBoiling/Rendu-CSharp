public partial class AppEntity 
{

    public Server.InfoComponent info { get { return (Server.InfoComponent)GetComponent(AppComponentsLookup.Info); } }
    public bool hasInfo { get { return HasComponent(AppComponentsLookup.Info); } }

    public void AddInfo(Server.AppType newAppType, int newMainKey, int newSubKey)
    {
        var index = AppComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component.AppType = newAppType;
        component.MainKey = newMainKey;
        component.SubKey = newSubKey;
        AddComponent(index, component);
    }

    public void ReplaceInfo(Server.AppType newAppType, int newMainKey, int newSubKey) 
    {
        var index = AppComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component.AppType = newAppType;
        component.MainKey = newMainKey;
        component.SubKey = newSubKey;
        ReplaceComponent(index, component);
    }

    public void RemoveInfo() 
    {
        RemoveComponent(AppComponentsLookup.Info);
    }
}


public sealed partial class AppMatcher 
{

    static Entitas.Matcher.IMatcher<AppEntity> _matcherInfo;

    public static Entitas.Matcher.IMatcher<AppEntity> Info 
    {
        get 
        {
            if (_matcherInfo == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<AppEntity>)Entitas.Matcher.Matcher<AppEntity>.AllOf(AppComponentsLookup.Info);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherInfo = matcher;
            }
            return _matcherInfo;
        }
    }
}
