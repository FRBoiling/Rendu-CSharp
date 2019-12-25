public static class AppComponentsLookup 
{
    public const int Channal = 0;
    public const int Info = 1;

    public const int TotalComponents = 2;

    public static readonly string[] componentNames = {
        "Channal",
        "Info"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.ChannalComponent),
        typeof(Server.InfoComponent)
    };
}
