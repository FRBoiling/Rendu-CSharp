using Entitas.Matcher;
public sealed partial class MessageMatcher
{

    public static IAllOfMatcher<MessageEntity> AllOf(params int[] indices) 
    {
        return Matcher<MessageEntity>.AllOf(indices);
    }

    public static IAllOfMatcher<MessageEntity> AllOf(params IMatcher<MessageEntity>[] matchers) 
    {
          return Matcher<MessageEntity>.AllOf(matchers);
    }

    public static IAnyOfMatcher<MessageEntity> AnyOf(params int[] indices) 
    {
          return Matcher<MessageEntity>.AnyOf(indices);
    }

    public static IAnyOfMatcher<MessageEntity> AnyOf(params IMatcher<MessageEntity>[] matchers) 
    {
          return Matcher<MessageEntity>.AnyOf(matchers);
    }
}
