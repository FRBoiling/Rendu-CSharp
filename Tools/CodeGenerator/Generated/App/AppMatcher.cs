using Entitas.Matcher;
public sealed partial class AppMatcher
{

    public static IAllOfMatcher<AppEntity> AllOf(params int[] indices) 
    {
        return Matcher<AppEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<AppEntity> AllOf(params IMatcher<AppEntity>[] matchers) 
    {
          return Matcher<AppEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<AppEntity> AnyOf(params int[] indices) 
    {
          return Matcher<AppEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<AppEntity> AnyOf(params IMatcher<AppEntity>[] matchers) 
    {
          return Matcher<AppEntity>.AnyOf(matchers);
    }
}
