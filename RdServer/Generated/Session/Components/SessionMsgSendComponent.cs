public partial class SessionEntity 
{

    public Server.MsgSendComponent msgSend { get { return (Server.MsgSendComponent)GetComponent(SessionComponentsLookup.MsgSend); } }
    public bool hasMsgSend { get { return HasComponent(SessionComponentsLookup.MsgSend); } }

    public void AddMsgSend(long newLastSendTime)
    {
        var index = SessionComponentsLookup.MsgSend;
        var component = (Server.MsgSendComponent)CreateComponent(index, typeof(Server.MsgSendComponent));
        component.LastSendTime = newLastSendTime;
        AddComponent(index, component);
    }

    public void ReplaceMsgSend(long newLastSendTime) 
    {
        var index = SessionComponentsLookup.MsgSend;
        var component = (Server.MsgSendComponent)CreateComponent(index, typeof(Server.MsgSendComponent));
        component.LastSendTime = newLastSendTime;
        ReplaceComponent(index, component);
    }

    public void RemoveMsgSend() 
    {
        RemoveComponent(SessionComponentsLookup.MsgSend);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherMsgSend;

    public static Entitas.Matcher.IMatcher<SessionEntity> MsgSend 
    {
        get 
        {
            if (_matcherMsgSend == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.MsgSend);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherMsgSend = matcher;
            }
            return _matcherMsgSend;
        }
    }
}
