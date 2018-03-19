using LogLib;
using ServerFrameWork;
using TcpLib.TcpSrc;

namespace ApiLib
{
    public partial class Api : AbstractClient
    {
        protected override void ExcuteCommand(string cmd)
        {
            throw new System.NotImplementedException();
        }

        protected override void InitClient()
        {
            if (InitSocket())
            {
                Connect2GateServer();
            }
        }

        public override void ExitClient()
        {
            IsRuning = false;
            ExitSocket();
        }

        protected override void Process()
        {
            TcpMgr.Inst.Update();
            ProcessLogic();
        }
    }
}
