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
    /// <summary>
    /// 客户端监听 连接保持 类
    /// </summary>
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
            MarkConnectTag(_tag);
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
            AddProcesser(Id<MSG_C2G_GetEncryptKey>.Value, OnResponse_GetEncryptkey);
            AddProcesser(Id<MSG_C2G_Heartbeat>.Value, OnResponse_HeartBeat);
            AddProcesser(Id<MSG_C2G_Login>.Value, OnResponse_Login);
            AddProcesser(Id<MSG_C2G_CreateRole>.Value, OnResponse_CreateRole);            
        }

        protected override void ProcessLogic()
        {
 
        }
    
    }
}
