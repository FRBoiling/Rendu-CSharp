using Entitas;
using Entitas.Attributes;
using Microsoft.IO;
using Rd.Networking;
using Rd.Networking.IOCP;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    [Context("Network")]
    public class NetworkComponent : IComponent
    {
        [EntityIndex]
        public NetworkType NetworkType;
        public ChannelType ChannelType;
        public SessionType SessionType;
        public IPEndPoint IpEndPoint;
    }

    [Context("Network")]
    public class NetworkService : IComponent
    {
        public AService Service;
    }

}
