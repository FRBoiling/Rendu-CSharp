public static class TestComponentsLookup 
{
    public const int Destroy = 0;
    public const int Name = 1;
    public const int Normal = 2;
    public const int Player = 3;
    public const int Unique = 4;

    public const int TotalComponents = 5;

    public static readonly string[] componentNames = {
        "Destroy",
        "Name",
        "Normal",
        "Player",
        "Unique"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Components.DestroyComponent),
        typeof(Components.NameComponent),
        typeof(Components.NormalComponent),
        typeof(Components.PlayerComponent),
        typeof(Components.UniqueComponent)
    };
}
