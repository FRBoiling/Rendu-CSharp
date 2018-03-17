using ServerFrameWork;
using System;
using TcpLib.TcpSrc;

namespace BattleManagerServerLib
{
    public partial class Api:AbstractServer
    {
        protected override void InitServer()
        {
            ApiTag.Type = ServerType.BattleManager;
            InitProtocol();

            InitClusterManagerServer();
            //InitBattleServer();
        }

        public override void ExitServer()
        {
        }

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            m_CMServer.Process();
            //m_BattleServer.Update();
        }

        protected override void ExcuteCommand(string cmd)
        {
        }
    }
}
