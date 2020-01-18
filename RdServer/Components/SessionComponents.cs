using Entitas;
using Entitas.Attributes;
using Rd.Networking;
using Rd.Networking.IOCP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{

    [Context("Session")]
    public class PlayerKeyComponent:IComponent
    {
        public int Key;
    }

    [Context("Session")]
    public class ServerKeyComponent : IComponent
    {
        public int Key;
    }

    [Context("Session")]
    [FlagPrefix("Is")]
    public class OfflineComponent : IComponent
    {
    }

    [Context("Session")]
    public class ChannelComponent: IComponent
    {
        public AChannel Channel;
    }

    [Context("Session")]
    public class MsgRecvComponent:IComponent
    {
        public long LastRecvTime;
    }

    [Context("Session")]
    public class MsgSendComponent : IComponent
    {
        public long LastSendTime;
    }

    [Context("Session")]
    public class ResponseDispatcherComponent : IComponent
    {
        public ResponseDispatcher Dispatcher;
    }
}


