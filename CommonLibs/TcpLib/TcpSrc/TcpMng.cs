using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpLib.TcpSrc
{
    public class TcpMng
    {
        private volatile static TcpMng _instance = null;
        private static readonly object _lockrobject = new object();
        private TcpMng() { }
        public static TcpMng CreateInstance()
        {
            if (_instance == null)
            {
                lock (_lockrobject)
                {
                    if (_instance == null)
                        _instance = new TcpMng();
                }
            }
            return _instance;
        }

        Dictionary<ushort, Socket> _listeners = new Dictionary<ushort, Socket>();

        public void AddListenSocket(ushort port,Socket socket)
        {
            _listeners.Add(port, socket);
        }

        public Socket GetListenSocket(ushort port)
        {
            Socket socket = null;
            if (_listeners.TryGetValue(port,out socket))
            {
                return socket;
            }
            return null;
        }
    }
}
