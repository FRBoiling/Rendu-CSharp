public static class NetworkComponentsLookup 
{
    public const int Tcp = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames = {
        "Tcp"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Components.TcpComponent)
    };
}
