using DataParserLib;
using ServerFrameWork;

namespace GateServerLib
{
    public partial class Api
    {
        private ClientMgr _clientMgr;
        public ClientMgr ClientMgr { get => _clientMgr; }

        private void InitClients()
        {
            DataList serverConfig = XmlDataManager.Inst.GetDataList(ServerConfigConst.ServerConfig);
            string name = ApiTag.GetServerTagString();
            Data serverData = serverConfig.Get(name);
            ushort listenport = (ushort)serverData.GetInt("NETPort");
            _clientMgr = new ClientMgr(this);
            _clientMgr.Bind(listenport, 3);
            _clientMgr.Listen(listenport);
        }

        private void ClientsProcess()
        {
            _clientMgr.Process();
        }
    }
}
