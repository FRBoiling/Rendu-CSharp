using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class BattleServerMgr:AbstractServerMgr
    {

        private Api _api;
        public Api Api { get => _api; }
        public BattleServerMgr(Api api) : base()
        {
            _api = api;
        }
        protected override void InitListen(ushort port)
        {
            BattleServer battleServer = new BattleServer(this, port);
            battleServer.StartListen(true);
        }
    }
}
 