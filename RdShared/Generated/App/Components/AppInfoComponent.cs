public partial class AppEntity 
{

    public Components.InfoComponent info { get { return (Components.InfoComponent)GetComponent(AppComponentsLookup.Info); } }
    public bool hasInfo { get { return HasComponent(AppComponentsLookup.Info); } }

    public void AddInfo(string new_name, Consts.AppType new_appType, string new_key1)
    {
        var index = AppComponentsLookup.Info;
        var component = (Components.InfoComponent)CreateComponent(index, typeof(Components.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
        AddComponent(index, component);
    }

    public void ReplaceInfo(string new_name, Consts.AppType new_appType, string new_key1) 
    {
        var index = AppComponentsLookup.Info;
        var component = (Components.InfoComponent)CreateComponent(index, typeof(Components.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
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
