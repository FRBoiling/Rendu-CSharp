using Entitas;

public sealed partial class Test1Matcher
{
    public static IAllOfMatcher<Test1Entity> AllOf(params int[] indices)
    {
        return Matcher<Test1Entity>.AllOf(indices);
    }

    public static IAllOfMatcher<Test1Entity> AllOf(params IMatcher<Test1Entity>[] matchers)
    {
        return Matcher<Test1Entity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<Test1Entity> AnyOf(params int[] indices)
    {
        return Matcher<Test1Entity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<Test1Entity> AnyOf(params IMatcher<Test1Entity>[] matchers)
    {
        return Matcher<Test1Entity>.AnyOf(matchers);
    }
}