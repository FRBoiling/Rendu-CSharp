using Entitas.Matcher;
public sealed partial class AppMatcher 
{

    static IMatcher<AppEntity> _matcherComponentsInfo;

    public static IMatcher<AppEntity> ComponentsInfo 
    {
        get 
        {
            if (_matcherComponentsInfo == null) 
            {
                var matcher = (Matcher<AppEntity>)Matcher<AppEntity>.AllOf(AppComponentsLookup.ComponentsInfo);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherComponentsInfo = matcher;
            }
            return _matcherComponentsInfo;
        }
    }
}
