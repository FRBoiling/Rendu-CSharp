using Message.Server.Battle.Protocol.B2CM;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;

namespace BattleServerLib
{
    public class CMServer : AbstractTcpClient
    {
        ServerTag _serverTag = new ServerTag();
        Api _api = null;
        public ServerTag ServerTag
        {
            get { return _serverTag; }
            set { _serverTag = value; }
        }

        public CMServer(Api api, string ip, ushort port)
            : base(ip, port)
        {
            _api = api;
            _serverTag.ServerName = "ClusterManager";
            BindResponser();
            InitTcp();
        }

        protected override void ConnectedComplete(bool ret)
        {
            if (ret)
            {
                Console.WriteLine("connected to {0}"
                    , ServerTag.ServerName);
                RequsetRegister();
            }
            else
            {
                Console.WriteLine("connect failed, connect to {0} ip {4} port {5} again"
                    , ServerTag.ServerName, ServerTag.AreaId, ServerTag.ServerId, ServerTag.SubId,Ip,Port);
            }
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("switch off from {0}" 
                , ServerTag.ServerName);
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
                    id, ServerTag.ServerName, ServerTag.AreaId, ServerTag.ServerId, ServerTag.SubId);
            }
        }

        public void BindResponser()
        {
        }

        public void RequsetRegister()
        {
            Console.WriteLine("Requst Register to {0}"
               , ServerTag.ServerName);
            MSG_B2CM_REGISTER requset = new MSG_B2CM_REGISTER();
            requset.areaId = _api.ApiTag.AreaId;
            requset.serverId = _api.ApiTag.ServerId;
            requset.subId = _api.ApiTag.SubId;
            Send(requset);
        }


    }
}
