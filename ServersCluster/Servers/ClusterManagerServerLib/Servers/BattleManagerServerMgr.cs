using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class BattleManagerServerMgr : AbstractServerMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public BattleManagerServerMgr(Api api) : base()
        {
            _api = api;
        }

        protected override void InitServer(ushort port)
        {
            BattleManagerServer server = new BattleManagerServer(this, port);
            server.StartListen(true);
        }
    }
}
