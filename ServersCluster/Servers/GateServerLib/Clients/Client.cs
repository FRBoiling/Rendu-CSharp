using Engine.Foundation;
using LogLib;
using Message.Client.Gate.Protocol.CG;
using ServerFrameWork;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpLib;

namespace GateServerLib
{
    public partial class Client : AbstractTcpServer
    {
        ClientInfo _tag = new ClientInfo();

        public ClientInfo Tag
        {
            get { return _tag; }
        }

        private ClientMgr _manager;

        private AbstractServer _api;

        public Client(ClientMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _api = manager.Api;
        }

        protected override void AccpetComplete()
        {
            Socket workerSocket = Tcp.GetWorkSoket();
            _tag.IPEndPoint = (IPEndPoint)workerSocket.RemoteEndPoint;
            IPAddress remote_ip = _tag.IPEndPoint.Address;//获取远程连接IP 
            _tag.Ip = remote_ip.ToString();
            _tag.Port = _tag.IPEndPoint.Port;
            Log.Info("client {0} connected", _tag.GetServerTagString());
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Log.Info("client {0} disconnected", _tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_C2G_GET_ENCRYPTKEY>.Value, OnResponse_GetEncryptkey);
            AddProcesser(Id<MSG_C2G_HEARTBEAT>.Value, OnResponse_HeartBeat);
        }

        protected override void ProcessLogic()
        {
 
        }
    
    }
}
