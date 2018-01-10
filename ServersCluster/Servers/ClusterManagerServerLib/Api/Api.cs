using ServerFrameWork;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib
{
    public partial class Api : AbstractServer
    {
        public override void Init(string[] args)
        {
            InitProtocol();
            InitServers();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            TcpMgr.Inst.Update();
            UpdateServers();
        }

        public override void ExcuteCommand(string cmd)
        {
        }
    }
}
