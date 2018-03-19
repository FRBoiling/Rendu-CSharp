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

        void InitProtocol()
        {
            Message.Client.Gate.Protocol.CG.Api.GenerateId();
            Message.Gate.Client.Protocol.GC.Api.GenerateId();
        }

        protected override void InitClient()
        {
            if (InitSocket())
            {
                InitProtocol();
                Connect2GateServer();
            }
        }

        public override void ExitClient()
        {
            //throw new System.NotImplementedException();
        }

        protected override void Process()
        {
            TcpMgr.Inst.Update();
            ProcessLogic();
        }
    }
}
