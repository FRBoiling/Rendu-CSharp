using ServerFrameWork;
using System;
using System.IO;
using TcpLib;
using Engine.Foundation;
using Protocol.Battle.B2BM;
using Protocol.BattleManager.BM2B;

namespace BattleServerLib
{
    public class BMServer : AbstractTcpClient
    {
        private Api _api;

        ServerInfo _serverTag = new ServerInfo();
        public ServerInfo ServerTag
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

        protected override void ConnectedComplete()
        {
            Console.WriteLine("connected to {0}", ServerTag.Type);
            RequsetRegister();
        }
        protected override void ReConnectedComplete()
        {
            Console.WriteLine("re connected to {0}", ServerTag.Type);
        }
        protected override void DisconnectComplete()
        {
            Console.WriteLine("switch off from {0}"
                , ServerTag.Type);
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

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_BM2B_RETRUN_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream, int uid)
        {
            MSG_BM2B_RETRUN_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_BM2B_RETRUN_REGISTER>(stream);
            _serverTag.GroupId = (ushort)msg.GroupId;
            _serverTag.SubId = (ushort)msg.SubId;
            Console.WriteLine("registed success to {0}", ServerTag.GetServerTagString());
        }


        protected override void ProcessLogic()
        {
            throw new NotImplementedException();
        }

   
    }
}
