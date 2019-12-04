using Entitas.Matcher;
public sealed partial class Test2Matcher 
{

    static IMatcher<Test2Entity> _matcherTestComponentsTestNormal;

    public static IMatcher<Test2Entity> TestComponentsTestNormal 
    {
        get 
        {
            if (_matcherTestComponentsTestNormal == null) 
            {
                var matcher = (Matcher<Test2Entity>)Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.TestComponentsTestNormal);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherTestComponentsTestNormal = matcher;
            }
            return _matcherTestComponentsTestNormal;
        }
    }
}
