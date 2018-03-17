using ServerFrameWork;
using TcpLib.TcpSrc;

namespace WorldManagerServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer()
        {
            InitConfig();
            InitProtocol();
            InitServers();
        }

        public override void ExitServer()
        {
            throw new System.NotImplementedException();
        }

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            UpdateServers();
        }

        protected override void ExcuteCommand(string cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
