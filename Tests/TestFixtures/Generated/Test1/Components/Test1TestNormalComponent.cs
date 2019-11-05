public sealed partial class Test1Matcher {

    static Entitas.IMatcher<Test1Entity> _matcherTestNormal;

    public static Entitas.IMatcher<Test1Entity> TestNormal {
        get {
            if (_matcherTestNormal == null) {
                var matcher = (Entitas.Matcher<Test1Entity>)Entitas.Matcher<Test1Entity>.AllOf(Test1ComponentsLookup.TestNormal);
                matcher.componentNames = Test1ComponentsLookup.componentNames;
                _matcherTestNormal = matcher;
            }

            return _matcherTestNormal;
        }
    }
}
