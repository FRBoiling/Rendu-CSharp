using ServerFrameWork;
using System;
using TcpLib.TcpSrc;

namespace BattleManagerServerLib
{
    public partial class Api:AbstractServer
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
            //InitBattleServer();
        }

        public override void Exit()
        {
        }

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            m_CMServer.Update();
            //m_BattleServer.Update();
        }

        protected override void ExcuteCommand(string cmd)
        {
        }
    }
}
