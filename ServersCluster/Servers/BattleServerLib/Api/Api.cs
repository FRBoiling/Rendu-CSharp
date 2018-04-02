using ServerFrameWork;
using TcpLib.TcpSrc;

namespace BattleServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer()
        {
            ApiTag.Type = ServerType.Battle;
            InitProtocol();

            InitClusterManagerServer();
            //InitBattleManagerServer();
        }

        public override void ExitServer()
        {
        }

        protected override void Process()
        {
            TcpMgr.Inst.Process();
            m_CMServer.Process();
            //m_BMServer.Update();
        }

        protected override void ExcuteCmd(string cmd)
        {
        }
    }
}
