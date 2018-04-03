using Engine.Foundation;
using LogLib;
using Message.Gate.ClusterManager.Protocol.G2CM;
using ServerFrameWork;
using System.IO;
using TcpLib;

namespace ClusterManagerServerLib.Servers
{
    public class GateServer : AbstractTcpServer
    {
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
        {
            get { return _tag; }
        }

        private GateServerMgr _manager;

        public GateServer(GateServerMgr manager, ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.Type = ServerType.Gate;
        }

        public string GetKey()
        {
            return Tag.GetServerKey();
        }


        protected override void AccpetComplete()
        {
            MarkConnectTag(_tag);
            Log.Info("{0} server connected", _tag.GetServerTagString());
            _manager.AddAccpetServer(this);
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_G2CM_Register>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream, int uid)
        {
            MSG_G2CM_Register msg = ProtoBuf.Serializer.Deserialize<MSG_G2CM_Register>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Key = _tag.GetServerKey();
            Name = _tag.Type.ToString();
            if (_manager.AddServer(this))
            {
                Log.Info("{0} regist succese", Tag.GetServerTagString());
            }
        }

        protected override void DisconnectComplete()
        {
            Log.Info("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override void ProcessLogic()
        {
            throw new System.NotImplementedException();
        }
    }
}
