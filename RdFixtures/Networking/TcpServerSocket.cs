using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Rd.Networking
{
    public class TcpServerSocket : AbstractTcpSocket
    {
        public delegate void TcpServerSocketHandler(TcpServerSocket server, Socket client);

        private readonly Dictionary<string, Socket> _clients;

        public TcpServerSocket()
            : base(typeof(TcpServerSocket).FullName)
        {
            _clients = new Dictionary<string, Socket>();
        }

        public int count => _clients.Count;

        public event TcpServerSocketHandler OnClientConnected;

        public event TcpServerSocketHandler OnClientDisconnected;

        public void Listen(int port)
        {
            _logger.Info("Server is listening on port " + port + "...");
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
            _socket.Listen(128);
            _socket.BeginAccept(onAccepted, _socket);
        }

        public Socket GetClientWithRemoteEndPoint(IPEndPoint endPoint)
        {
            Socket socket;
            _clients.TryGetValue(keyForEndPoint(endPoint), out socket);
            return socket;
        }

        public override void Send(byte[] buffer)
        {
            if (_clients.Count != 0)
                foreach (var socket in _clients.Values.ToArray())
                    send(socket, buffer);
            else
                _logger.Debug("Server doesn't have any connected clients. Won't send.");
        }

        public void SendTo(byte[] buffer, IPEndPoint endPoint)
        {
            send(GetClientWithRemoteEndPoint(endPoint), buffer);
        }

        public void DisconnectClient(IPEndPoint endPoint)
        {
            var withRemoteEndPoint = GetClientWithRemoteEndPoint(endPoint);
            withRemoteEndPoint.Shutdown(SocketShutdown.Both);
            withRemoteEndPoint.BeginDisconnect(false, onDisconnectClient, withRemoteEndPoint);
        }

        public override void Disconnect()
        {
            _socket.Close();
            _logger.Info("Server stopped listening");
            foreach (var socket in _clients.Values.ToArray())
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.BeginDisconnect(false, onDisconnectClient, socket);
            }
        }

        private void onAccepted(IAsyncResult ar)
        {
            var asyncState = (Socket) ar.AsyncState;
            var client = (Socket) null;
            try
            {
                client = asyncState.EndAccept(ar);
            }
            catch (ObjectDisposedException ex)
            {
            }

            if (client == null)
                return;
            addClient(client);
            _socket.BeginAccept(onAccepted, _socket);
        }

        private void addClient(Socket client)
        {
            var key = keyForEndPoint((IPEndPoint) client.RemoteEndPoint);
            _clients.Add(key, client);
            _logger.Debug("Server accepted new client connection from " + key);
            receive(new ReceiveVO(client, new byte[client.ReceiveBufferSize]));
            if (OnClientConnected == null)
                return;
            OnClientConnected(this, client);
        }

        protected override void onReceived(IAsyncResult ar)
        {
            var asyncState = (ReceiveVO) ar.AsyncState;
            var bytesReceived = 0;
            try
            {
                bytesReceived = asyncState.socket.EndReceive(ar);
            }
            catch (SocketException ex)
            {
            }

            if (bytesReceived == 0)
            {
                if (!asyncState.socket.Connected)
                    return;
                removeClient(asyncState.socket);
            }
            else
            {
                var str = keyForEndPoint((IPEndPoint) asyncState.socket.RemoteEndPoint);
                _logger.Debug("Server received " + bytesReceived + " bytes from " + str);
                triggerOnReceived(asyncState, bytesReceived);
                receive(asyncState);
            }
        }

        private void removeClient(Socket socket)
        {
            var key = _clients.Single(kv => kv.Value == socket).Key;
            _clients.Remove(key);
            socket.Close();
            _logger.Debug("Client " + key + " disconnected from server");
            if (OnClientDisconnected == null)
                return;
            OnClientDisconnected(this, socket);
        }

        private void onDisconnectClient(IAsyncResult ar)
        {
            var client = (Socket) ar.AsyncState;
            var key = _clients.Single(kv => kv.Value == client).Key;
            _clients.Remove(key);
            client.EndDisconnect(ar);
            client.Close();
            _logger.Debug("Server disconnected client " + key);
        }
    }
}