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
            _clientMgr = new ClientMgr(this);
            _clientMgr.Bind(listenport, 3);
            _clientMgr.Listen(listenport);
        }

        private void UpdateClients()
        {
            _clientMgr.UpdateServers();
        }
    }
}
