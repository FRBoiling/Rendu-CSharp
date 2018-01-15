using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;
using Engine.Foundation;
using Message.Battle.BattleManager.Protocol.B2BM;
using Message.BattleManager.Battle.Protocol.BM2B;

namespace BattleServerLib
{
    public class BMServer : AbstractTcpClient
    {
        Api _api = null;

        ServerTag _serverTag = new ServerTag();
        public ServerTag ServerTag
        {
            get { return _serverTag; }
        }

        public BMServer(Api api, string ip, ushort port)
            : base(ip, port)
        {
            _api = api;
            _serverTag.Type = ServerType.BattleManager;
            BindResponser();
            InitTcp();
        }

        protected override void ConnectedComplete(bool ret)
        {
            if (ret)
            {
                Console.WriteLine("connected to {0}" , ServerTag.Type);
                RequsetRegister();
            }
            else
            {
                Console.WriteLine("connect failed, connect to {0} ip {1} port {2} again"
                    , ServerTag.GetServerTagString(), Ip,Port);
            }
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("switch off from {0}" 
                , ServerTag.Type);
        }

        public override void Update()
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
                    id, ServerTag.GetServerTagString());
            }
        }

        public void RequsetRegister()
        {
            Console.WriteLine("Requst Register to {0}"
               , ServerTag.Type);
            MSG_B2BM_REGISTER requset = new MSG_B2BM_REGISTER();
            requset.GroupId = _api.ApiTag.GroupId;
            requset.SubId = _api.ApiTag.SubId;
            Send(requset);
        }


        public void BindResponser()
        {
            AddResponser(Id<MSG_BM2B_RETRUN_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream)
        {
            MSG_BM2B_RETRUN_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_BM2B_RETRUN_REGISTER>(stream);
            _serverTag.GroupId = (ushort)msg.GroupId;
            _serverTag.SubId = (ushort)msg.SubId;
            Console.WriteLine("registed success to {0}", ServerTag.GetServerTagString());
        }



    }
}
