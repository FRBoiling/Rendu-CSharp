using ApiLib;
using LogLib;
using ServerFrameWork;
using TcpLib;

namespace ClientLib
{
    public partial class GateServer:AbstractTcpClient
    {
        private Api _api;

        ServerInfo _tag = new ServerInfo();
        public ServerInfo Tag
        {
            get { return _tag; }
        }

        public GateServer()
        {
            _tag.Type = ServerType.Gate;
        }

        public GateServer(Api api, string ip, ushort port)
            : base(ip, port)
        {
            _api = api;
            
            _tag.Ip = ip;
            _tag.Port = port;
        }

        public void InitConnectInfo(Api api, string ip, ushort port)
        {
            _api = api;
            base.Init(ip,port);
        }

        protected override void BindResponser()
        {
            Message.Client.Gate.Protocol.CG.Api.GenerateId();
            Message.Gate.Client.Protocol.GC.Api.GenerateId();
            
            BindResponse_Login();
            BindResponse();
        }

        protected override void ConnectedComplete(bool ret)
        {
            if (ret)
            {
                Log.Info("connected to {0}", Tag.Type);
            }
            else
            {
                Log.Warn("connect failed, connect to {0} ip {1} port {2} again"
                    , Tag.GetServerTagString(), Ip, Port);
            }
        }

        protected override void ProcessLogic()
        {

        }

        //public void Exit()
        //{
        //    base.Exit();
        //}

        protected override void DisconnectComplete()
        {
            Log.Info("switch off from {0}", Tag.GetServerTagString());
        }
    }
}
