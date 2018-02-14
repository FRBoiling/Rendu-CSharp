using Engine.Foundation;
using Message.World.ClusterManager.Protocol.W2CM;
using ServerFrameWork;
using System;
using System.IO;
using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class WorldServer : AbstractTcpServer
    {
        ServerTag _tag = new ServerTag();

        public ServerTag Tag
        {
            get { return _tag; }
        }

        private WorldServerMgr _manager;

        public WorldServer(WorldServerMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.Type = ServerType.World;
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
            AddProcesser(Id<MSG_W2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream,int uid)
        {
            MSG_W2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_W2CM_REGISTER>(stream);
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
