public static class ServerComponentsLookup {

    public const int Server = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames = {
        "Server"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(ServerComponent)
    };
}
