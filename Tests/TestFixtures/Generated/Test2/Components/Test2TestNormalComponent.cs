using Entitas;

public sealed partial class Test2Matcher
{
    private static IMatcher<Test2Entity> _matcherTestNormal;

    public static IMatcher<Test2Entity> TestNormal
    {
        get
        {
            if (_matcherTestNormal == null)
            {
                var matcher = (Matcher<Test2Entity>) Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.TestNormal);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherTestNormal = matcher;
            }

            return _matcherTestNormal;
        }
    }
}