using Entitas.Matcher;
public sealed partial class SessionMatcher
{

    public static IAllOfMatcher<SessionEntity> AllOf(params int[] indices) 
    {
        return Matcher<SessionEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<SessionEntity> AllOf(params IMatcher<SessionEntity>[] matchers) 
    {
          return Matcher<SessionEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<SessionEntity> AnyOf(params int[] indices) 
    {
          return Matcher<SessionEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<SessionEntity> AnyOf(params IMatcher<SessionEntity>[] matchers) 
    {
          return Matcher<SessionEntity>.AnyOf(matchers);
    }
}
