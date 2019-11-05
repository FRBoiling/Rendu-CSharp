using Entitas;

public sealed partial class Test2Matcher
{
    public static IAllOfMatcher<Test2Entity> AllOf(params int[] indices)
    {
        return Matcher<Test2Entity>.AllOf(indices);
    }

    public static IAllOfMatcher<Test2Entity> AllOf(params IMatcher<Test2Entity>[] matchers)
    {
        return Matcher<Test2Entity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<Test2Entity> AnyOf(params int[] indices)
    {
        return Matcher<Test2Entity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<Test2Entity> AnyOf(params IMatcher<Test2Entity>[] matchers)
    {
        return Matcher<Test2Entity>.AnyOf(matchers);
    }
}