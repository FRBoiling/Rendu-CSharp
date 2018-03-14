using System;

namespace BattleServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.Battle.BattleManager.Protocol.B2BM.Api.GenerateId();
            Message.Battle.ClusterManager.Protocol.B2CM.Api.GenerateId();

            Message.ClusterManager.Battle.Protocol.CM2B.Api.GenerateId();
            Message.BattleManager.Battle.Protocol.BM2B.Api.GenerateId();
        }

        CMServer m_CMServer;
        void InitClusterManagerServer()
        {
            m_CMServer = new CMServer(this, "127.0.0.1", 8505);
            m_CMServer.Connect();
        }

        BMServer m_BMServer;
        void InitBattleManagerServer()
        {
            m_BMServer = new BMServer(this,"127.0.0.1", 9999);
            m_BMServer.Connect();
        }

  

    }
}
