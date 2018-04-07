using Engine.Foundation;
using LogLib;
using Protocol.Battle.B2CM;
using ServerFrameWork;
using System;
using System.IO;
using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class BattleServer : AbstractTcpServer
    {
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
        {
            get { return _tag; }
        }

        private BattleServerMgr _manager;

        public BattleServer(BattleServerMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.Type = ServerType.Battle;
        }


        protected override void AccpetComplete()
        {
            Log.Info("{0} server connected", _tag.Type);
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Log.Info("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_B2CM_Register>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream,int uid)
        {
            MSG_B2CM_Register msg = ProtoBuf.Serializer.Deserialize<MSG_B2CM_Register>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Key = _tag.GetServerKey();
            Name = _tag.Type.ToString();
            if (_manager.AddServer(this))
            {
                Log.Info("{0} regist succese", Tag.GetServerTagString());
            }
        }

        protected override void ProcessLogic()
        {
            throw new NotImplementedException();
        }
    }
}
