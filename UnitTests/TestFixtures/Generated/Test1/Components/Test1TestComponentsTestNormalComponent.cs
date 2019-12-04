using Entitas.Matcher;
public sealed partial class Test1Matcher 
{

    static IMatcher<Test1Entity> _matcherTestComponentsTestNormal;

    public static IMatcher<Test1Entity> TestComponentsTestNormal 
    {
        get 
        {
            if (_matcherTestComponentsTestNormal == null) 
            {
                var matcher = (Matcher<Test1Entity>)Matcher<Test1Entity>.AllOf(Test1ComponentsLookup.TestComponentsTestNormal);
                matcher.componentNames = Test1ComponentsLookup.componentNames;
                _matcherTestComponentsTestNormal = matcher;
            }
            return _matcherTestComponentsTestNormal;
        }
    }
}
