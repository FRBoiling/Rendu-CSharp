using ServerFrameWork;

namespace ClusterManagerServerLib
{
    public partial class Api : AbstractServer
    {
        public override void Init(string[] args)
        {
            InitProtocol();
            InitBattleManagerServer();
            InitBattleServer();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            m_BMServer.Update();
            BMServer1.Update();
            BMServer2.Update();

            m_BattleServer.Update();
            BattleServer1.Update();
            BattleServer2.Update();
        }

        public override void ExcuteCommand(string cmd)
        {
        }
    }
}
