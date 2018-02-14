using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class WorldManagerServerMgr : AbstractServerMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public WorldManagerServerMgr(Api api) : base()
        {
            _api = api;
        }

        protected override void InitServer(ushort port)
        {
            WorldManagerServer server = new WorldManagerServer(this, port);
            server.StartListen(true);
        }
    }
}
