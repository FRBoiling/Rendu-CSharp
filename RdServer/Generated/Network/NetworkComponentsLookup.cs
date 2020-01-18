public static class NetworkComponentsLookup 
{
    public const int Network = 0;
    public const int NetworkService = 1;

    public const int TotalComponents = 2;

    public static readonly string[] componentNames = {
        "Network",
        "NetworkService"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.NetworkComponent),
        typeof(Server.NetworkService)
    };
}
