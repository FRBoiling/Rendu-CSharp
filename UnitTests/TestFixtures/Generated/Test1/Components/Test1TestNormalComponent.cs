using Entitas.Matcher;
public sealed partial class Test1Matcher 
{

    static IMatcher<Test1Entity> _matcherTestNormal;

    public static IMatcher<Test1Entity> TestNormal 
    {
        get 
        {
            if (_matcherTestNormal == null) 
            {
                var matcher = (Matcher<Test1Entity>)Matcher<Test1Entity>.AllOf(Test1ComponentsLookup.TestNormal);
                matcher.componentNames = Test1ComponentsLookup.componentNames;
                _matcherTestNormal = matcher;
            }
            return _matcherTestNormal;
        }
    }
}
