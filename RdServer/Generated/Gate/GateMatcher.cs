using Entitas.Matcher;
public sealed partial class GateMatcher
{

    public static IAllOfMatcher<GateEntity> AllOf(params int[] indices) 
    {
        return Matcher<GateEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<GateEntity> AllOf(params IMatcher<GateEntity>[] matchers) 
    {
          return Matcher<GateEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<GateEntity> AnyOf(params int[] indices) 
    {
          return Matcher<GateEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<GateEntity> AnyOf(params IMatcher<GateEntity>[] matchers) 
    {
          return Matcher<GateEntity>.AnyOf(matchers);
    }
}
