public sealed partial class ServerMatcher {

    public static Entitas.IAllOfMatcher<ServerEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<ServerEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<ServerEntity> AllOf(params Entitas.IMatcher<ServerEntity>[] matchers) {
          return Entitas.Matcher<ServerEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<ServerEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<ServerEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<ServerEntity> AnyOf(params Entitas.IMatcher<ServerEntity>[] matchers) {
          return Entitas.Matcher<ServerEntity>.AnyOf(matchers);
    }
}
