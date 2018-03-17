using DataParserLib;
using ServerFrameWork;

namespace WorldManagerServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.World.WorldManager.Protocol.W2WM.Api.GenerateId();
            Message.WorldManager.World.Protocol.WM2W.Api.GenerateId();
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
