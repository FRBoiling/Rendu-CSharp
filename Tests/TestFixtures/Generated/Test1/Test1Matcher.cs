public sealed partial class Test1Matcher {

    public static Entitas.IAllOfMatcher<Test1Entity> AllOf(params int[] indices) {
        return Entitas.Matcher<Test1Entity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<Test1Entity> AllOf(params Entitas.IMatcher<Test1Entity>[] matchers) {
          return Entitas.Matcher<Test1Entity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<Test1Entity> AnyOf(params int[] indices) {
          return Entitas.Matcher<Test1Entity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<Test1Entity> AnyOf(params Entitas.IMatcher<Test1Entity>[] matchers) {
          return Entitas.Matcher<Test1Entity>.AnyOf(matchers);
    }
}
