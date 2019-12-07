using Entitas.Matcher;
public sealed partial class ZoneMatcher
{

    public static IAllOfMatcher<ZoneEntity> AllOf(params int[] indices) 
    {
        return Matcher<ZoneEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<ZoneEntity> AllOf(params IMatcher<ZoneEntity>[] matchers) 
    {
          return Matcher<ZoneEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<ZoneEntity> AnyOf(params int[] indices) 
    {
          return Matcher<ZoneEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<ZoneEntity> AnyOf(params IMatcher<ZoneEntity>[] matchers) 
    {
          return Matcher<ZoneEntity>.AnyOf(matchers);
    }
}
