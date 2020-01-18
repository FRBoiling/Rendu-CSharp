public static class SessionComponentsLookup 
{
    public const int Channel = 0;
    public const int Destory = 1;
    public const int MsgRecv = 2;
    public const int MsgSend = 3;
    public const int Offline = 4;
    public const int PlayerKey = 5;
    public const int ResponseDispatcher = 6;
    public const int ServerKey = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "Channel",
        "Destory",
        "MsgRecv",
        "MsgSend",
        "Offline",
        "PlayerKey",
        "ResponseDispatcher",
        "ServerKey"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Server.ChannelComponent),
        typeof(Server.DestoryComponent),
        typeof(Server.MsgRecvComponent),
        typeof(Server.MsgSendComponent),
        typeof(Server.OfflineComponent),
        typeof(Server.PlayerKeyComponent),
        typeof(Server.ResponseDispatcherComponent),
        typeof(Server.ServerKeyComponent)
    };
}
