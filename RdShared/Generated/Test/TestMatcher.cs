using Entitas.Matcher;
public sealed partial class TestMatcher
{

    public static IAllOfMatcher<TestEntity> AllOf(params int[] indices) 
    {
        return Matcher<TestEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<TestEntity> AllOf(params IMatcher<TestEntity>[] matchers) 
    {
          return Matcher<TestEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<TestEntity> AnyOf(params int[] indices) 
    {
          return Matcher<TestEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<TestEntity> AnyOf(params IMatcher<TestEntity>[] matchers) 
    {
          return Matcher<TestEntity>.AnyOf(matchers);
    }
}
