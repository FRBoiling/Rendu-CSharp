public static class MessageComponentsLookup 
{
    public const int MessageDispatcher = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames = {
        "MessageDispatcher"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.Components.MessageDispatcherComponent)
    };
}
