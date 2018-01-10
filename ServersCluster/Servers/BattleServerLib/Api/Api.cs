using ServerFrameWork;
using TcpLib.TcpSrc;

namespace BattleServerLib
{
    public partial class Api : AbstractServer
    {
        public override void Init(string[] args)
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

            //InitBattleManagerServer();
            InitClusterManagerServer();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            //m_BMServer.Update();
            m_CMServer.Update();
        }

        public override void ExcuteCommand(string cmd)
        {
        }
    }
}
