using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class BMServerMgr : AbstractServerMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public BMServerMgr(Api api) : base()
        {
            _api = api;
        }

        protected override void InitServer(ushort port)
        {
            BMServer battleManagerServer = new BMServer(this, port);
            battleManagerServer.StartListen(true);
        }
    }
}
