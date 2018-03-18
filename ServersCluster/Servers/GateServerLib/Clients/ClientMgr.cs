using TcpLib;

namespace GateServerLib
{
    public class ClientMgr:AbstractServerMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public ClientMgr(Api api) : base()
        {
            _api = api;
        }
        protected override void InitServer(ushort port)
        {
            Client client = new Client(this, port);
            client.StartListen(true);
        }
    }
}
 