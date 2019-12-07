public static class GateComponentsLookup 
{
    public const int Info = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames = {
        "Info"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.InfoComponent)
    };
}
