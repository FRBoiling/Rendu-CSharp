public partial class GateEntity 
{

    public Server.InfoComponent info { get { return (Server.InfoComponent)GetComponent(GateComponentsLookup.Info); } }
    public bool hasInfo { get { return HasComponent(GateComponentsLookup.Info); } }

    public void AddInfo(string new_name, Consts.AppType new_appType, string new_key1)
    {
        var index = GateComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
        AddComponent(index, component);
    }

    public void ReplaceInfo(string new_name, Consts.AppType new_appType, string new_key1) 
    {
        var index = GateComponentsLookup.Info;
        var component = (Server.InfoComponent)CreateComponent(index, typeof(Server.InfoComponent));
        component._name = new_name;
        component._appType = new_appType;
        component._key1 = new_key1;
        ReplaceComponent(index, component);
    }

    public void RemoveInfo() 
    {
        RemoveComponent(GateComponentsLookup.Info);
    }
}


public sealed partial class GateMatcher 
{

    static Entitas.Matcher.IMatcher<GateEntity> _matcherInfo;

    public static Entitas.Matcher.IMatcher<GateEntity> Info 
    {
        get 
        {
            if (_matcherInfo == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<GateEntity>)Entitas.Matcher.Matcher<GateEntity>.AllOf(GateComponentsLookup.Info);
                matcher.componentNames = GateComponentsLookup.componentNames;
                _matcherInfo = matcher;
            }
            return _matcherInfo;
        }
    }
}
