using ServerFrameWork;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer()
        {
            ApiTag.Type = ServerType.ClusterManager;

            InitConfig();
            InitProtocol();
            InitServers();
        }

        public override void ExitServer()
        {
        }

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            UpdateServers();
        }

        protected override void ExcuteCommand(string cmd)
        {
        }
    }
}
