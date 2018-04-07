using DataParserLib;
using ServerFrameWork;

namespace GateServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Protocol.Client.C2G.Api.GenerateId();
            Protocol.Gate.G2C.Api.GenerateId();
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
