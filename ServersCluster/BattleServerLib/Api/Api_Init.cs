using System;

namespace BattleServerLib
{
    public partial class Api
    {
        void InitProtocol()
        {
            Message.Server.Battle.Protocol.B2CM.Api.GenerateId();
            Message.Server.Battle.Protocol.B2BM.Api.GenerateId();

            Message.Server.BattleManager.Protocol.BM2B.Api.GenerateId();
            Message.Server.ClusterManager.Protocol.CM2B.Api.GenerateId();
        }

        BMServer m_BMServer;
        void InitBattleManagerServer()
        {
            m_BMServer = new BMServer(this,"127.0.0.1", 9999);
            m_BMServer.Connect();
        }

        CMServer m_CMServer;
        void InitClusterManagerServer()
        {
            m_CMServer = new CMServer(this, "127.0.0.1", 8003);
            m_CMServer.Connect();
        }

    }
}
