using ServerFrameWork;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib
{
    public partial class Api : AbstractServer
    {
        public override void Init(string[] args)
        {
            ApiTag.Type = ServerType.ClusterManager;
            if (args.Length>=2)
            {
                ApiTag.GroupId = ushort.Parse(args[0]);
                ApiTag.SubId = ushort.Parse(args[1]);
            }

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
