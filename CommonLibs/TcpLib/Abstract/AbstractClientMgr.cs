using LogLib;
using System;
using System.Collections.Generic;
using TcpLib.TcpSrc;
using UtilityLib;

namespace TcpLib
{
    public abstract class AbstractClientMgr
    {
        private List<AbstractTcpClient> _connectedClients = new List<AbstractTcpClient>();
        private object _allClientsLock = new object();

        private Dictionary<string, AbstractTcpClient> _Clients = new Dictionary<string, AbstractTcpClient>();
        private List<AbstractTcpClient> _removeClients = new List<AbstractTcpClient>();
      

        public AbstractClientMgr()
        {
        }

        public abstract void InitConnect(string ip,ushort port);

        public void Process()
        {
            lock (_allClientsLock)
            {
                foreach (var item in _connectedClients)
                {
                    try
                    {
                        item.Process();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            if (_removeClients.Count > 0)
            {
                foreach (var item in _removeClients)
                {
                    _connectedClients.Remove(item);
                }
                _removeClients.Clear();
            }
        }

        public void AddConnectedServer(AbstractTcpClient client)
        {
            if (client == null)
            {
                Log.Error("AddConnected server failed:server is null");
                return;
            }
            else
            {
                lock (_allClientsLock)
                {
                    _connectedClients.Add(client);
                }
            }
        }

        public void RemoveServer(AbstractTcpClient client)
        {
            if (client == null)
            {
                Log.Error("RemoveServer server failed:server is null");
                return;
            }
            else
            {
                lock (_allClientsLock)
                {
                    if (_connectedClients.Contains(client))
                    {
                        _connectedClients.Remove(client);
                        _Clients.Remove(client.Key);
                    }
                }
            }
        }

        public bool AddServer(AbstractTcpClient client)
        {
            if (client == null)
            {
                Log.Error("add client failed: client is null");
                return false;
            }
            else
            {
                AbstractTcpClient temp;
                if (_Clients.TryGetValue(client.Key, out temp))
                {
                    _removeClients.Add(client);
                    Log.Warn("{0}_{1} repeated add !", temp.Name, temp.Key);
                    return false;
                }
                else
                {
                    Log.Debug("{0}_{1} add success ! ", client.Name, client.Key);
                    _Clients.Add(client.Key, client);
                    return true;
                }

            }
        }


    }
}
