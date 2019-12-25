public partial class ConfigEntity 
{

    public Server.XmlDataComponent xmlData { get { return (Server.XmlDataComponent)GetComponent(ConfigComponentsLookup.XmlData); } }
    public bool hasXmlData { get { return HasComponent(ConfigComponentsLookup.XmlData); } }

    public void AddXmlData(int newKey)
    {
        var index = ConfigComponentsLookup.XmlData;
        var component = (Server.XmlDataComponent)CreateComponent(index, typeof(Server.XmlDataComponent));
        component.Key = newKey;
        AddComponent(index, component);
    }

    public void ReplaceXmlData(int newKey) 
    {
        var index = ConfigComponentsLookup.XmlData;
        var component = (Server.XmlDataComponent)CreateComponent(index, typeof(Server.XmlDataComponent));
        component.Key = newKey;
        ReplaceComponent(index, component);
    }

    public void RemoveXmlData() 
    {
        RemoveComponent(ConfigComponentsLookup.XmlData);
    }
}


public sealed partial class ConfigMatcher 
{

    static Entitas.Matcher.IMatcher<ConfigEntity> _matcherXmlData;

    public static Entitas.Matcher.IMatcher<ConfigEntity> XmlData 
    {
        get 
        {
            if (_matcherXmlData == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<ConfigEntity>)Entitas.Matcher.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.XmlData);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherXmlData = matcher;
            }
            return _matcherXmlData;
        }
    }
}
