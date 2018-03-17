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

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            m_CMServer.Update();
            //m_BMServer.Update();
        }

        protected override void ExcuteCommand(string cmd)
        {
        }
    }
}
