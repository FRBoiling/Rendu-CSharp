using DataParserLib;
using ServerFrameWork;

namespace GateServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.Client.Gate.Protocol.CG.Api.GenerateId();
            Message.Gate.Client.Protocol.GC.Api.GenerateId();
        }

        void InitConfig()
        {
            //frTODO:初始化config数据
        }

        void UpdateConfig()
        {
            //frTODO:动态加载config数据
        }

    }
}
