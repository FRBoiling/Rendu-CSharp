using TcpLib;

namespace GateServerLib.Servers
{
    public class WorldManagerServerMgr : AbstractClientMgr
    {

        private Api _api;
        public Api Api { get => _api; }
        public WorldManagerServerMgr(Api api) : base()
        {
            _api = api;
        }

        public override void InitConnect(string ip, ushort port)
        {
            WorldManagerServer server = new WorldManagerServer(this,ip, port);
            server.ReConnect();
        }
    }
}
