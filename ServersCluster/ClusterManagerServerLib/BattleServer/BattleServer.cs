using Engine.Foundation;
using Message.Server.Battle.Protocol.B2CM;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class BattleServer : AbstractTcpServer
    {
        ServerTag _clientTag = new ServerTag();

        public ServerTag ClientTag
        {
            get { return _clientTag; }
        }

        public BattleServer(Api server, ushort port)
            : base(port)
        {
            _clientTag.ServerName = "Battle";
            BindResponser();
            InitTcp();
        }

        protected override void AccpetComplete()
        {
            //Console.WriteLine("{0}-{1}-{2}-{3} switch in"
            //    , ClientTag.ServerName, ClientTag.AreaId, ClientTag.ServerId, ClientTag.SubId);
            Console.WriteLine("{0} switch in"
                , ClientTag.ServerName);
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("{0}-{1}-{2}-{3} switch off"
                , ClientTag.ServerName, ClientTag.AreaId, ClientTag.ServerId, ClientTag.SubId);
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
                Console.WriteLine("got unsupported packet {0} from {1} {2}-{3}-{4}",
                    id, ClientTag.ServerName, ClientTag.AreaId, ClientTag.ServerId, ClientTag.SubId);
            }
        }

        public void BindResponser()
        {
            AddResponser(Id<MSG_B2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream)
        {
            MSG_B2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_B2CM_REGISTER>(stream);
            _clientTag.AreaId = (ushort)msg.areaId;
            _clientTag.ServerId = (ushort)msg.serverId;
            _clientTag.SubId = (ushort)msg.subId;
            Console.WriteLine("{0}-{1}-{2}-{3} regist succese", ClientTag.ServerName,ClientTag.AreaId,ClientTag.ServerId,ClientTag.SubId);
        }

    }
}
