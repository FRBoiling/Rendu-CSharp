using Entitas.Matcher;
public sealed partial class ServerMatcher
{

    public static IAllOfMatcher<ServerEntity> AllOf(params int[] indices) 
    {
        return Matcher<ServerEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<ServerEntity> AllOf(params IMatcher<ServerEntity>[] matchers) 
    {
          return Matcher<ServerEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<ServerEntity> AnyOf(params int[] indices) 
    {
          return Matcher<ServerEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<ServerEntity> AnyOf(params IMatcher<ServerEntity>[] matchers) 
    {
          return Matcher<ServerEntity>.AnyOf(matchers);
    }
}
