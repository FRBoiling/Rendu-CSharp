using Engine.Foundation;
using IOCPLib;
using Message.Server.Battle.Protocol.B2BM;
using Message.Server.BattleManager.Protocol.BM2B;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace BattleManagerServerLib
{

    public class BattleServer : IOCPServer
    {
        ServerTag _clientTag = new ServerTag();
        Api _api = null;
        public ServerTag ClientTag
        {
            get { return _clientTag; }
            set { _clientTag = value; }
        }

        public BattleServer(Api server, ushort port)
            : base(port,1024)
        {
            _api = server;
            _clientTag.ServerName = "Battle";
            BindResponser();
        }

        public void Update()
        {
            OnProcessProtocal();
        }

        public delegate void Responseer(MemoryStream stream);
        private Dictionary<uint, Responseer> _responsers = new Dictionary<uint, Responseer>();

        protected override void Response(uint id, System.IO.MemoryStream stream)
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

        public bool Send<T>(T msg) where T : global::ProtoBuf.IExtensible
        {
            MemoryStream body = new MemoryStream();
            ProtoBuf.Serializer.Serialize(body, msg);

            MemoryStream head = new MemoryStream(sizeof(ushort) + sizeof(uint));
            ushort len = (ushort)body.Length;
            head.Write(BitConverter.GetBytes(len), 0, 2);
            head.Write(BitConverter.GetBytes(Id<T>.Value), 0, 4);
            return Send(head, body);
        }

  
        public void AddResponser(uint id, Responseer responser)
        {
            _responsers.Add(id, responser);
        }

        public void BindResponser()
        {
            AddResponser(Id<MSG_B2BM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream)
        {
            MSG_B2BM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_B2BM_REGISTER>(stream);
            _clientTag.AreaId = (ushort)msg.areaId;
            _clientTag.ServerId = (ushort)msg.serverId;
            _clientTag.SubId = (ushort)msg.subId;
            Console.WriteLine("{0}-{1}-{2}-{3} regist succese", ClientTag.ServerName, ClientTag.AreaId, ClientTag.ServerId, ClientTag.SubId);

            MSG_BM2B_RETRUN_REGISTER ret = new MSG_BM2B_RETRUN_REGISTER();
            ret.areaId = msg.areaId;
            ret.serverId = msg.serverId;
            ret.subId = msg.subId;
            Send(ret);
        }
    }
}
