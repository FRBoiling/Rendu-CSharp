using ServerFrameWork;
using TcpLib.TcpSrc;

namespace BattleServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer(string[] args)
        {
            if (args.Length == 2)
            {
                ApiTag.GroupId = ushort.Parse(args[0]);
                ApiTag.SubId = ushort.Parse(args[1]);
            }
            else
            {

            }
            InitProtocol();

            InitClusterManagerServer();
            //InitBattleManagerServer();
        }

        public override void Exit()
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
