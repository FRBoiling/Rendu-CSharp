using Engine.Foundation;
using IOCPLib;
using Protocol.Battle.B2BM;
using Protocol.BattleManager.BM2B;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace BattleManagerServerLib
{

    public class BattleServer : IOCPServer
    {
        ServerInfo _clientTag = new ServerInfo();
        Api _api = null;
        public ServerInfo ClientTag
        {
            get { return _clientTag; }
            set { _clientTag = value; }
        }

        public BattleServer(Api server, ushort port)
            : base(port,1024)
        {
            _api = server;
            _clientTag.Type = ServerType.Battle ;
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
                Console.WriteLine("got unsupported packet {0} from {1}",
                    id, ClientTag.GetServerTagString());
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
            _clientTag.GroupId = (ushort)msg.GroupId;
            _clientTag.SubId = (ushort)msg.SubId;
            Console.WriteLine("{0} regist succese", ClientTag.GetServerTagString());

            MSG_BM2B_RETRUN_REGISTER ret = new MSG_BM2B_RETRUN_REGISTER();
            ret.GroupId = msg.GroupId;
            ret.SubId = msg.SubId;
            Send(ret);
        }
    }
}
