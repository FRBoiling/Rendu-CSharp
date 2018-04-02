using Engine.Foundation;
using LogLib;
using Message.World.WorldManager.Protocol.W2WM;
using Message.WorldManager.World.Protocol.WM2W;
using ServerFrameWork;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpLib;

namespace WorldManagerServerLib
{
    public partial class WorldServer : AbstractTcpServer
    {
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
        {
            get { return _tag; }
        }

        private WorldServerMgr _manager;

        private AbstractServer _api;

        public WorldServer(WorldServerMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _api = manager.Api;
            _tag.Type = ServerType.World;
        }


        protected override void AccpetComplete()
        {
            Socket workerSocket = Tcp.GetWorkSoket();
            _tag.IPEndPoint = (IPEndPoint)workerSocket.RemoteEndPoint;
            IPAddress remote_ip = _tag.IPEndPoint.Address;//获取远程连接IP 
            _tag.Ip = remote_ip.ToString();
            _tag.Port = _tag.IPEndPoint.Port;
            Log.Info("{0} server connected", _tag.GetServerTagString());
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Log.Info("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_W2WM_Register>.Value, OnResponse_Regist);
            AddProcesser(Id<MSG_W2WM_Heartbeat>.Value, OnResponse_Heartbeat);
        }

        protected override void ProcessLogic()
        {
            
        }

        private void OnResponse_Regist(MemoryStream stream,int uid)
        {
            MSG_W2WM_Register msg = ProtoBuf.Serializer.Deserialize<MSG_W2WM_Register>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Key = _tag.GetServerKey();
            Name = _tag.Type.ToString();
            Log.Debug("{0} recv regist info {1}",_api.ApiTag.GetServerTagString(),_tag.GetServerTagString());
            MSG_WM2W_RETRUN_REGISTER response = new MSG_WM2W_RETRUN_REGISTER();
            response.GroupId = _api.ApiTag.GroupId;
            response.SubId = _api.ApiTag.SubId;
            if (_manager.AddServer(this))
            {
                Log.Info("{0} regist succese", Tag.GetServerTagString());
            }
            else
            {
                Log.Warn("{0} regist fail", Tag.GetServerTagString());
            }
        }

    
    }
}
