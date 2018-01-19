//using System;
//using System.Collections.Generic;

//namespace ServerFrameWork
//{
//    public abstract class AbstractServerMgr
//    {
//        private List<AbstractTcpServer> _connectedServers = new List<AbstractTcpServer>();
//        private object _allServersLock = new object();

//        private Dictionary<string, AbstractTcpServer> _servers = new Dictionary<string, AbstractTcpServer>();
//        private List<AbstractTcpServer> _removeServers = new List<AbstractTcpServer>();

//        private Api _api;
//        public Api Api { get => _api;  }

//        public AbstractServerMgr(Api api)
//        {
//            _api = api;
//        }

//        public void Bind(ushort port,int backLog)
//        {
//            TcpMgr.Inst.Bind(port,backLog);
//        }

//        public void Listen(ushort port)
//        {
//            TcpMgr.Inst.Listen(port,InitServer);
//        }

//        protected abstract void InitServer(ushort port);

//        public void UpdateServers()
//        {
//            lock (_allServersLock)
//            {
//                foreach (var item in _connectedServers)
//                {
//                    try
//                    {
//                        item.Update();
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine(e.ToString());
//                    }
//                }
//            }
//            if (_removeServers.Count>0)
//            {
//                foreach (var item in _removeServers)
//                {
//                    _connectedServers.Remove(item);
//                }
//                _removeServers.Clear();
//            }
//        }

//        public void AddAccpetServer(AbstractTcpServer server)
//        {
//            if (server == null)
//            {
//                Console.WriteLine("AddAccpet server failed:server is null");
//                return;
//            }
//            else
//            {
//                lock (_allServersLock)
//                {
//                    _connectedServers.Add(server);
//                }
//            }
//        }

//        public void RemoveServer(AbstractTcpServer server)
//        {
//            if (server == null)
//            {
//                Console.WriteLine("RemoveServer server failed:server is null");
//                return;
//            }
//            else
//            {
//                lock (_allServersLock)
//                {
//                    if (_connectedServers.Contains(server))
//                    {
//                        _connectedServers.Remove(server);
//                        _servers.Remove(server.Key);
//                    }
//                }
//            }
//        }

//        public bool AddServer(AbstractTcpServer server)
//        {
//            if (server == null)
//            {
//                Console.WriteLine("add server failed: server is null");
//                return false;
//            }
//            else
//            {
//                AbstractTcpServer temp;
//                if (_servers.TryGetValue(server.Key,out temp))
//                {
//                    _removeServers.Add(server);
//                    Console.WriteLine("repeated regist ! server {0}_{1} already registed",temp.Name,temp.Key);
//                    return false;
//                }
//                else
//                {
//                    _servers.Add(server.Key, server);
//                    return true;
//                }

//            }
//        }


//    }
//}
 