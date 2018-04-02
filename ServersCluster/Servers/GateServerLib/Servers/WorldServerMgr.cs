using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpLib;

namespace GateServerLib.Servers
{
    public class WorldServerMgr : AbstractClientMgr
    {
        private Api _api;
        public Api Api { get => _api; }
        public WorldServerMgr(Api api) : base()
        {
            _api = api;
        }

        public override void InitConnect(string ip, ushort port)
        {
            WorldServer server = new WorldServer(this, ip, port);
            server.ReConnect();
        }
    }
}
