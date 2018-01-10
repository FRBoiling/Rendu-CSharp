using System;
using System.Collections.Generic;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib.Server
{
    public class BattleServerMgr
    {
        private List<BattleServer> AllBattleServers = new List<BattleServer>();
        private object AllBattleServersLock = new object();

        private Dictionary<string, BattleServer> BattleServers = new Dictionary<string, BattleServer>();

        private Api _api;
        public Api Api { get => _api;  }

        public BattleServerMgr(Api api)
        {
            _api = api;
        }

        public void Bind(ushort port,int backLog)
        {
            TcpMgr.Inst.Bind(port,backLog);
        }

        public void Listen(ushort port)
        {
            TcpMgr.Inst.Listen(port,InitServer);
        }

        public void InitServer(ushort port)
        {
            BattleServer battleServer = new BattleServer(this, port);
            battleServer.StartListen(true);
        }

        public void UpdateServers()
        {
            lock (AllBattleServersLock)
            {
                foreach (var item in AllBattleServers)
                {
                    try
                    {
                        item.Update();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }

        public void AddAccpet(BattleServer server)
        {
            if (server == null)
            {

            }
            else
            {
                lock (AllBattleServersLock)
                {
                   AllBattleServers.Add(server);
                }
            }
        }

        public void RemoveServer(BattleServer server)
        {
            if (server == null)
            {
                Console.WriteLine("distroy the server failed:server is null");
                return;
            }
            else
            {
                lock (AllBattleServersLock)
                {
                    if (AllBattleServers.Contains(server))
                    {
                        AllBattleServers.Remove(server);
                    }
                }
            }
        }



    }
}
 