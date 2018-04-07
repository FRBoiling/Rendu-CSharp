using ClusterManagerServerLib.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterManagerServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Protocol.ClusterManager.CM2BM.Api.GenerateId();
            Protocol.ClusterManager.CM2B.Api.GenerateId();
            Protocol.ClusterManager.CM2WM.Api.GenerateId();
            Protocol.ClusterManager.CM2W.Api.GenerateId();


            Protocol.BattleManager.BM2CM.Api.GenerateId();
            Protocol.Battle.B2CM.Api.GenerateId();
            Protocol.WorldManager.WM2CM.Api.GenerateId();
            Protocol.World.W2CM.Api.GenerateId();
        }


        void InitConfig()
        {

        }
      
      
    }
}
