using Entitas.Matcher;
public sealed partial class AppMatcher 
{

    static IMatcher<AppEntity> _matcherInfo;

    public static IMatcher<AppEntity> Info 
    {
        get 
        {
            if (_matcherInfo == null) 
            {
                var matcher = (Matcher<AppEntity>)Matcher<AppEntity>.AllOf(AppComponentsLookup.Info);
                matcher.componentNames = AppComponentsLookup.componentNames;
                _matcherInfo = matcher;
            }
            return _matcherInfo;
        }
    }
}
