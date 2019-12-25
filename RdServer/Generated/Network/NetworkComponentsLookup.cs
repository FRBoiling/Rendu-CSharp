public static class NetworkComponentsLookup 
{
    public const int Connector = 0;
    public const int Listener = 1;
    public const int Service = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "Connector",
        "Listener",
        "Service"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.ConnectorComponent),
        typeof(Server.ListenerComponent),
        typeof(Server.ServiceComponent)
    };
}
