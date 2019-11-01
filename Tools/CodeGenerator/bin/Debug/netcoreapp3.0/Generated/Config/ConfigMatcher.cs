public sealed partial class ConfigMatcher {

    public static Entitas.IAllOfMatcher<ConfigEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<ConfigEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<ConfigEntity> AllOf(params Entitas.IMatcher<ConfigEntity>[] matchers) {
          return Entitas.Matcher<ConfigEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<ConfigEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<ConfigEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<ConfigEntity> AnyOf(params Entitas.IMatcher<ConfigEntity>[] matchers) {
          return Entitas.Matcher<ConfigEntity>.AnyOf(matchers);
    }
}
