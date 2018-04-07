using System.IO;
using Engine.Foundation;
using LogLib;
using Protocol.World.W2WM;
using Protocol.WorldManager.WM2W;
using ServerFrameWork;
using TcpLib;

namespace WorldServerLib
{
    public partial class WorldManagerServer : AbstractTcpClient
    {
        private Api _api;

        ServerInfo _tag = new ServerInfo();
        public ServerInfo Tag
        {
            get { return _tag; }
        }

        public WorldManagerServer(Api api, string ip, ushort port)
            :base(ip,port)
        {
            _api = api;
            _tag.Type = ServerType.WorldManager;
            _tag.Ip = ip;
            _tag.Port = port;
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_WM2W_RETRUN_REGISTER>.Value, OnResponse_Regist);
        }

        protected override void ConnectedComplete()
        {
                Log.Info("connected to {0}", Tag.Type);
                RequsetRegister();
        }
        protected override void ReConnectedComplete()
        {
            Log.Info("re connected to {0}", Tag.Type);
        }

        protected override void DisconnectComplete()
        {
            Log.Info("switch off from {0}"
            , Tag.GetServerTagString());
        }

        protected override void ProcessLogic()
        {
        }


        public void RequsetRegister()
        {
            MSG_W2WM_Register requset = new MSG_W2WM_Register();
            requset.GroupId = _api.ApiTag.GroupId;
            requset.SubId = _api.ApiTag.SubId;
            Send(requset);
            Log.Info("request register to {0}", _tag.Type);
        }

        private void OnResponse_Regist(MemoryStream stream, int uid)
        {
            MSG_WM2W_RETRUN_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_WM2W_RETRUN_REGISTER>(stream);
            //_tag.GroupId = (ushort)msg.GroupId;
            //_tag.SubId = (ushort)msg.SubId;
            //_tag.Ip = Ip;
            //_tag.Port = Port;
            Log.Info("registed success to {0}", Tag.GetServerTagString());
        }

   
    }
}
