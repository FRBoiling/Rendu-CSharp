public partial class SessionEntity 
{

    public Server.ChannelComponent channel { get { return (Server.ChannelComponent)GetComponent(SessionComponentsLookup.Channel); } }
    public bool hasChannel { get { return HasComponent(SessionComponentsLookup.Channel); } }

    public void AddChannel(Rd.Networking.IOCP.AChannel newChannel)
    {
        var index = SessionComponentsLookup.Channel;
        var component = (Server.ChannelComponent)CreateComponent(index, typeof(Server.ChannelComponent));
        component.Channel = newChannel;
        AddComponent(index, component);
    }

    public void ReplaceChannel(Rd.Networking.IOCP.AChannel newChannel) 
    {
        var index = SessionComponentsLookup.Channel;
        var component = (Server.ChannelComponent)CreateComponent(index, typeof(Server.ChannelComponent));
        component.Channel = newChannel;
        ReplaceComponent(index, component);
    }

    public void RemoveChannel() 
    {
        RemoveComponent(SessionComponentsLookup.Channel);
    }
}


public sealed partial class SessionMatcher 
{

    static Entitas.Matcher.IMatcher<SessionEntity> _matcherChannel;

    public static Entitas.Matcher.IMatcher<SessionEntity> Channel 
    {
        get 
        {
            if (_matcherChannel == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<SessionEntity>)Entitas.Matcher.Matcher<SessionEntity>.AllOf(SessionComponentsLookup.Channel);
                matcher.componentNames = SessionComponentsLookup.componentNames;
                _matcherChannel = matcher;
            }
            return _matcherChannel;
        }
    }
}
