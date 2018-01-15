using System;
using System.Collections.Generic;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib.Server
{
    public class BattleServerMgr:AbstractServerMgr
    {
        public BattleServerMgr(Api api) : base(api)
        {
        }
        protected override void InitServer(ushort port)
        {
            BattleServer battleServer = new BattleServer(this, port);
            battleServer.StartListen(true);
        }
    }
}
 