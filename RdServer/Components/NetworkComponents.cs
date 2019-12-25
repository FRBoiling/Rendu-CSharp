using Entitas;
using Entitas.Attributes;
using Microsoft.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public enum ChannelType
    {
        Listener,
        Connector
    }

    public enum NetworkType
    {
        Default,
        TCP,
        Http,
    }

    [Context("Network")]
    public class ConnectorComponent : IComponent
    {
        public IPEndPoint RemoteEndPoint;
        public bool Reconnect;
    }

    [Context("Network")]
    public class ListenerComponent : IComponent                                                     
    {
        public IPEndPoint LocalEndPoint;
        public bool Relisten;
    }

    [Context("Network")]
    public class ServiceComponent : IComponent
    {
        public NetworkType ProtocolType;
        public ChannelType ChannelType;

        public RecyclableMemoryStreamManager MemoryStreamManager;

        public SocketAsyncEventArgs EventArgs;

        public HashSet<long> NeedStartSendChannel;

        public Socket Socket;
    }

    [Unique]
    public class ChannalComponent : IComponent
    {
        public Socket Socket;
    }


}
