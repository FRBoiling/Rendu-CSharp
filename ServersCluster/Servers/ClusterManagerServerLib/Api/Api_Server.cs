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
        BMServer BMServer;
        void InitBattleManagerServer()
        {
            m_BMServer = new BMServer(this, 8002);
            m_BMServer.StartListen();

            BMServer1 = new BMServer(this, 8002);
            BMServer1.StartListen();

            BMServer2 = new BMServer(this, 8002);
            BMServer2.StartListen();
        }

        BattleServer m_BattleServer;
        BattleServer BattleServer1;
        BattleServer BattleServer2;
        void InitBattleServer()
        {
            m_BattleServer = new BattleServer(this, 8003);
            m_BattleServer.StartListen();
            BattleServer1 = new BattleServer(this, 8003);
            BattleServer1.StartListen();
            BattleServer2 = new BattleServer(this, 8003);
            BattleServer2.StartListen();
        }
    }
}
