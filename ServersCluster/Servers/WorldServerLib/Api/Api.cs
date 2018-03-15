using ServerFrameWork;
using TcpLib.TcpSrc;

namespace WorldServerLib
{
    public partial class Api : AbstractServer
    {
        protected override void InitServer(string[] args)
        {
            ApiTag.Type = ServerType.World;
            if (args.Length >= 2)
            {
                ApiTag.GroupId = ushort.Parse(args[0]);
                ApiTag.SubId = ushort.Parse(args[1]);
            }
            InitProtocol();
            InitServers();
        }

        public override void ExitServer()
        {
            throw new System.NotImplementedException();
        }

        protected override void Update()
        {
            TcpMgr.Inst.Update();
            UpdateServers();
        }

        protected override void ExcuteCommand(string cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}
