using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class WorldServerMgr:AbstractServerMgr
    {

        private Api _api;
        public Api Api { get => _api; }
        public WorldServerMgr(Api api) : base()
        {
            _api = api;
        }
        protected override void InitListen(ushort port)
        {
            WorldServer server = new WorldServer(this, port);
            server.StartListen(true);
        }
    }
}
 