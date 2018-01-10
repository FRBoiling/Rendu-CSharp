using Engine.Foundation;
using Message.Battle.ClusterManager.Protocol.B2CM;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib.Server
{
    public class BattleServer : AbstractTcpServer
    {
        ServerTag _tag = new ServerTag();

        public ServerTag Tag
        {
            get { return _tag; }
        }

        private BattleServerMgr _manager;

        public BattleServer(BattleServerMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.ServerType = "Battle";
            BindResponser();
            InitTcp();
        }

        protected override void AccpetComplete()
        {

            Console.WriteLine("{0} switch in"
                , Tag.ServerType);
            _manager.AddAccpet(this);
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("{0} switch off"
                , Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        public void Update() 
        {
            OnProcessProtocal();
        }

        public delegate void Responseer(MemoryStream stream);
        private Dictionary<uint, Responseer> _responsers = new Dictionary<uint, Responseer>();

        public void AddResponser(uint id, Responseer responser)
        {
            _responsers.Add(id, responser);
        }

        protected override void Response(uint id, MemoryStream stream)
        {
            Responseer responser = null;
            if (_responsers.TryGetValue(id, out responser))
            {
                responser(stream);
            }
            else
            {
                Console.WriteLine("got unsupported packet {0} from {1}",
                    id, Tag.GetServerTagString());
            }
        }

        public void BindResponser()
        {
            AddResponser(Id<MSG_B2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream)
        {
            MSG_B2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_B2CM_REGISTER>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Console.WriteLine("{0} regist succese", Tag.GetServerTagString());
        }

    }
}
