using ServerFrameWork;
using System;
using TcpLib.TcpSrc;

namespace BattleManagerServerLib
{
    public partial class Api:AbstractServer
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

            InitClusterManagerServer();
            //InitBattleServer();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            TcpMgr.Inst.Update();
            m_CMServer.Update();
            //m_BattleServer.Update();
        }

        public override void ExcuteCommand(string cmd)
        {
        }
    }
}
