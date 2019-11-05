using System;

public static class ServerComponentsLookup
{
    public const int Server = 0;

    public const int TotalComponents = 1;

    public static readonly string[] componentNames =
    {
        "Server"
    };

    public static readonly Type[] componentTypes =
    {
        typeof(ServerComponent)
    };
}