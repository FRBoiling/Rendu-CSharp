public partial class SessionEntity 
{

    public Server.MsgRecvComponent msgRecv { get { return (Server.MsgRecvComponent)GetComponent(SessionComponentsLookup.MsgRecv); } }
    public bool hasMsgRecv { get { return HasComponent(SessionComponentsLookup.MsgRecv); } }

    public void AddMsgRecv(long newLastRecvTime)
    {
        var index = SessionComponentsLookup.MsgRecv;
        var component = (Server.MsgRecvComponent)CreateComponent(index, typeof(Server.MsgRecvComponent));
        component.LastRecvTime = newLastRecvTime;
        AddComponent(index, component);
    }

    public void ReplaceMsgRecv(long newLastRecvTime) 
    {
        var index = SessionComponentsLookup.MsgRecv;
        var component = (Server.MsgRecvComponent)CreateComponent(index, typeof(Server.MsgRecvComponent));
        component.LastRecvTime = newLastRecvTime;
        ReplaceComponent(index, component);
    }

    public void RemoveMsgRecv() 
    {
        RemoveComponent(SessionComponentsLookup.MsgRecv);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherMsgRecv;

    public static Entitas.Matcher.IMatcher<SessionEntity> MsgRecv 
    {
        get 
        {
            if (_matcherMsgRecv == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.MsgRecv);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherMsgRecv = matcher;
            }
            return _matcherMsgRecv;
        }
    }
}
