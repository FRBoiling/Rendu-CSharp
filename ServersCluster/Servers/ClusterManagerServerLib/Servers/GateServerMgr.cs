using TcpLib;

namespace ClusterManagerServerLib.Servers
{
    public class GateServerMgr:AbstractServerMgr
    {

        private Api _api;
        public Api Api { get => _api; }
        public GateServerMgr(Api api) : base()
        {
            _api = api;
        }
        protected override void InitListen(ushort port)
        {
            GateServer server = new GateServer(this, port);
            server.StartListen(true);
        }
    }
}
 