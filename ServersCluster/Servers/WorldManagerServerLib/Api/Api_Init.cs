using DataParserLib;
using ServerFrameWork;

namespace WorldManagerServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Protocol.World.W2WM.Api.GenerateId();
            Protocol.WorldManager.WM2W.Api.GenerateId();
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
