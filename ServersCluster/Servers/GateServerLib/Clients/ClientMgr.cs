using TcpLib;

namespace GateServerLib
{
    /// <summary>
    /// 游戏客户端 监听管理类  
    /// </summary>
    public class ClientMgr:AbstractServerMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public ClientMgr(Api api) : base()
        {
            _api = api;
        }
        protected override void InitListen(ushort port)
        {
            Client client = new Client(this, port);
            client.StartListen(true);
        }
    }
}
 