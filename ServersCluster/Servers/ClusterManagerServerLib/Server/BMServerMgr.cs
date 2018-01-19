using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManagerServerLib.Server
{
    public class BMServerMgr : AbstractServerMgr
    {
        public BMServerMgr(Api api) : base(api)
        {
        }

        protected override void InitServer(ushort port)
        {
            BMServer battleManagerServer = new BMServer(this, port);
            battleManagerServer.StartListen(true);
        }
    }
}
