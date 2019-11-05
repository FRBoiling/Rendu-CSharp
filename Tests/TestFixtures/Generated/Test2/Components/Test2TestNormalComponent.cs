public sealed partial class Test2Matcher {

    static Entitas.IMatcher<Test2Entity> _matcherTestNormal;

    public static Entitas.IMatcher<Test2Entity> TestNormal {
        get {
            if (_matcherTestNormal == null) {
                var matcher = (Entitas.Matcher<Test2Entity>)Entitas.Matcher<Test2Entity>.AllOf(Test2ComponentsLookup.TestNormal);
                matcher.componentNames = Test2ComponentsLookup.componentNames;
                _matcherTestNormal = matcher;
            }

            return _matcherTestNormal;
        }
    }
}
