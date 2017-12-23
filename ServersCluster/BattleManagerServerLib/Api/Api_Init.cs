using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleManagerServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.Server.BattleManager.Protocol.BM2CM.Api.GenerateId();
            Message.Server.BattleManager.Protocol.BM2B.Api.GenerateId();

            Message.Server.ClusterManager.Protocol.CM2BM.Api.GenerateId();
            Message.Server.Battle.Protocol.B2BM.Api.GenerateId();
        }

        CMServer m_CMServer;

        void InitClusterManagerServer()
        {
            m_CMServer = new CMServer(this,"127.0.0.1", 8002);
            m_CMServer.Connect();
        }

        BattleServer m_BattleServer;
        void InitBattleServer()
        {
            m_BattleServer = new BattleServer(this, 9999);
            m_BattleServer.Start();
        }

    }
}
