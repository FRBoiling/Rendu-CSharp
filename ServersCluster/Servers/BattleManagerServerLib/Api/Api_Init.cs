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
            Protocol.BattleManager.BM2CM.Api.GenerateId();
            Protocol.BattleManager.BM2B.Api.GenerateId();

            Protocol.ClusterManager.CM2BM.Api.GenerateId();
            Protocol.Battle.B2BM.Api.GenerateId();
        }

        CMServer m_CMServer;
        void InitClusterManagerServer()
        {
            m_CMServer = new CMServer(this,"127.0.0.1", 8502);
            m_CMServer.ReConnect();
        }

        BattleServer m_BattleServer;
        void InitBattleServer()
        {
            m_BattleServer = new BattleServer(this, 9999);
            m_BattleServer.Start();
        }

    }
}
