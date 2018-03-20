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

        ushort listenport;
        void InitConfig()
        {
            DataList serverConfig = XmlDataManager.Inst.GetDataList(ServerConfigConst.ServerConfig);
            string name = ApiTag.GetServerTagString();
            Data serverData = serverConfig.Get(name);
            listenport = (ushort)serverData.GetInt("Port");
        }
      
    }
}
