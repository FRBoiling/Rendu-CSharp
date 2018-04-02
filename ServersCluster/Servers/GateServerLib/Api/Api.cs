using ServerFrameWork;
using TcpLib.TcpSrc;

namespace GateServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer()
        {
            InitConfig();
            InitProtocol();
            InitServers();
            InitClients();
        }

        public override void ExitServer()
        {
            throw new System.NotImplementedException();
        }

        protected override void Process()
        {
            TcpMgr.Inst.Process();
            ClientsProcess();
            ServersProcess();
        }

        protected override void ExcuteCmd(string cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
