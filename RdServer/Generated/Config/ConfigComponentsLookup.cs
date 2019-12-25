public static class ConfigComponentsLookup 
{
    public const int XmlData = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames = {
        "XmlData"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.XmlDataComponent)
    };
}
