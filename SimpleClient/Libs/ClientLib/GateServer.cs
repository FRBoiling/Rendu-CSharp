using LogLib;
using ServerFrameWork;
using TcpLib;

namespace ClientLib
{
    public partial class GateServer:AbstractTcpClient
    {
        ServerInfo _tag = new ServerInfo();
        public ServerInfo Tag
        {
            get { return _tag; }
        }

        public GateServer()
        {
            _tag.Type = ServerType.Gate;
        }

        public GateServer(string ip, ushort port)
            : base(ip, port)
        {
            _tag.Ip = ip;
            _tag.Port = port;
        }

        protected override void BindResponser()
        {
            Protocol.Client.C2G.Api.GenerateId();
            Protocol.Gate.G2C.Api.GenerateId();
            BindResponse_Login();
            BindResponse();
        }

        protected override void ConnectedComplete()
        {
            Log.Info("connected to {0}", Tag.Type);
        }

        protected override void ReConnectedComplete()
        {
            Log.Info("re connected to {0}", Tag.Type);
        }

        protected override void ProcessLogic()
        {

        }

        protected override void DisconnectComplete()
        {
            Log.Info("switch off from {0}", Tag.GetServerTagString());
        }
    }
}
