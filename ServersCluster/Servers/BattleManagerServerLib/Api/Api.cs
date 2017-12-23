using ServerFrameWork;
using System;

namespace BattleManagerServerLib
{
    public partial class Api:AbstractServer
    {
        public override void Init(string[] args)
        {
            if (args.Length == 3)
            {
                ApiTag.AreaId = ushort.Parse(args[0]);
                ApiTag.ServerId = ushort.Parse(args[1]);
                ApiTag.SubId = ushort.Parse(args[2]);
            }
            else
            {

            }
            InitProtocol();

            //InitClusterManagerServer();
            InitBattleServer();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            //m_CMServer.Update();
            m_BattleServer.Update();
        }

        public override void ExcuteCommand(string cmd)
        {
        }
    }
}
