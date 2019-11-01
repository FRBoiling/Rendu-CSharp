public sealed partial class NetworkMatcher {

    public static Entitas.IAllOfMatcher<NetworkEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<NetworkEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<NetworkEntity> AllOf(params Entitas.IMatcher<NetworkEntity>[] matchers) {
          return Entitas.Matcher<NetworkEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<NetworkEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<NetworkEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<NetworkEntity> AnyOf(params Entitas.IMatcher<NetworkEntity>[] matchers) {
          return Entitas.Matcher<NetworkEntity>.AnyOf(matchers);
    }
}
