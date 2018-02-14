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
            Message.ClusterManager.BattleManager.Protocol.CM2BM.Api.GenerateId();
            Message.ClusterManager.Battle.Protocol.CM2B.Api.GenerateId();
            Message.ClusterManager.WorldManager.Protocol.CM2WM.Api.GenerateId();
            Message.ClusterManager.World.Protocol.CM2W.Api.GenerateId();


            Message.BattleManager.ClusterManager.Protocol.BM2CM.Api.GenerateId();
            Message.Battle.ClusterManager.Protocol.B2CM.Api.GenerateId();
            Message.WorldManager.ClusterManager.Protocol.WM2CM.Api.GenerateId();
            Message.World.ClusterManager.Protocol.W2CM.Api.GenerateId();
        }

      
      
    }
}
