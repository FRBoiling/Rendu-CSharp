using Engine.Foundation;
using Message.Battle.ClusterManager.Protocol.B2CM;
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
            Console.WriteLine("{0} server connected", _tag.Type);
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override AbstractParsePacket InitPacketParser()
        {
            return new Packet1();   
        }
        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_B2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream,int uid)
        {
            MSG_B2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_B2CM_REGISTER>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Key = _tag.GetServerKey();
            Name = _tag.Type.ToString();
            if (_manager.AddServer(this))
            {
                Console.WriteLine("{0} regist succese", Tag.GetServerTagString());
            }
        }


    }
}
