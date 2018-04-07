using System;

namespace BattleServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Protocol.Battle.B2BM.Api.GenerateId();
            Protocol.Battle.B2CM.Api.GenerateId();

            Protocol.ClusterManager.CM2B.Api.GenerateId();
            Protocol.BattleManager.BM2B.Api.GenerateId();
        }

        CMServer m_CMServer;
        void InitClusterManagerServer()
        {
            m_CMServer = new CMServer(this, "127.0.0.1", 8505);
            m_CMServer.ReConnect();
        }

        BMServer m_BMServer;
        void InitBattleManagerServer()
        {
            m_BMServer = new BMServer(this,"127.0.0.1", 9999);
            m_BMServer.ReConnect();
        }

  

    }
}
