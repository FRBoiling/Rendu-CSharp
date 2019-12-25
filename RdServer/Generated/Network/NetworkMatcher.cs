using Entitas.Matcher;
public sealed partial class NetworkMatcher
{

    public static IAllOfMatcher<NetworkEntity> AllOf(params int[] indices) 
    {
        return Matcher<NetworkEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<NetworkEntity> AllOf(params IMatcher<NetworkEntity>[] matchers) 
    {
          return Matcher<NetworkEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<NetworkEntity> AnyOf(params int[] indices) 
    {
          return Matcher<NetworkEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<NetworkEntity> AnyOf(params IMatcher<NetworkEntity>[] matchers) 
    {
          return Matcher<NetworkEntity>.AnyOf(matchers);
    }
}
