public partial class ZoneEntity 
{

    public Server.InfoComponent info { get { return (Server.InfoComponent)GetComponent(ZoneComponentsLookup.Info); } }
    public bool hasInfo { get { return HasComponent(ZoneComponentsLookup.Info); } }

    public void AddInfo(string new_name, Consts.AppType new_appType, string new_key1)
    {
        var index = ZoneComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
        AddComponent(index, component);
    }

    public void ReplaceInfo(string new_name, Consts.AppType new_appType, string new_key1) 
    {
        var index = ZoneComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
        ReplaceComponent(index, component);
    }

    public void RemoveInfo() 
    {
        RemoveComponent(ZoneComponentsLookup.Info);
    }
}


public sealed partial class ZoneMatcher 
{

    static Entitas.Matcher.IMatcher<ZoneEntity> _matcherInfo;

    public static Entitas.Matcher.IMatcher<ZoneEntity> Info 
    {
        get 
        {
            if (_matcherInfo == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<ZoneEntity>)Entitas.Matcher.Matcher<ZoneEntity>.AllOf(ZoneComponentsLookup.Info);
                matcher.componentNames = ZoneComponentsLookup.componentNames;
                _matcherInfo = matcher;
            }
            return _matcherInfo;
        }
    }
}
