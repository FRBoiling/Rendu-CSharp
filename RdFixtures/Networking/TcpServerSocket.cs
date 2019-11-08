using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Rd.Networking
{
    public class TcpServerSocket : AbstractTcpSocket
    {
        private readonly Dictionary<string, Socket> _clients;

        public event TcpServerSocket.TcpServerSocketHandler OnClientConnected;

        public event TcpServerSocket.TcpServerSocketHandler OnClientDisconnected;

        public int count
        {
            get { return this._clients.Count; }
        }

        public TcpServerSocket()
            : base(typeof(TcpServerSocket).FullName)
        {
            this._clients = new Dictionary<string, Socket>();
        }

        public void Listen(int port)
        {
            this._logger.Info("Server is listening on port " + (object) port + "...");
            this._socket.Bind((EndPoint) new IPEndPoint(IPAddress.Any, port));
            this._socket.Listen(128);
            this._socket.BeginAccept(new AsyncCallback(this.onAccepted), (object) this._socket);
        }

        public Socket GetClientWithRemoteEndPoint(IPEndPoint endPoint)
        {
            Socket socket;
            this._clients.TryGetValue(AbstractTcpSocket.keyForEndPoint(endPoint), out socket);
            return socket;
        }

        public override void Send(byte[] buffer)
        {
            if (this._clients.Count != 0)
            {
                foreach (Socket socket in this._clients.Values.ToArray<Socket>())
                    this.send(socket, buffer);
            }
            else
                this._logger.Debug("Server doesn't have any connected clients. Won't send.");
        }

        public void SendTo(byte[] buffer, IPEndPoint endPoint)
        {
            this.send(this.GetClientWithRemoteEndPoint(endPoint), buffer);
        }

        public void DisconnectClient(IPEndPoint endPoint)
        {
            Socket withRemoteEndPoint = this.GetClientWithRemoteEndPoint(endPoint);
            withRemoteEndPoint.Shutdown(SocketShutdown.Both);
            withRemoteEndPoint.BeginDisconnect(false, new AsyncCallback(this.onDisconnectClient), (object) withRemoteEndPoint);
        }

        public override void Disconnect()
        {
            this._socket.Close();
            this._logger.Info("Server stopped listening");
            foreach (Socket socket in this._clients.Values.ToArray<Socket>())
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.BeginDisconnect(false, new AsyncCallback(this.onDisconnectClient), (object) socket);
            }
        }

        private void onAccepted(IAsyncResult ar)
        {
            Socket asyncState = (Socket) ar.AsyncState;
            Socket client = (Socket) null;
            try
            {
                client = asyncState.EndAccept(ar);
            }
            catch (ObjectDisposedException ex)
            {
            }

            if (client == null)
                return;
            this.addClient(client);
            this._socket.BeginAccept(new AsyncCallback(this.onAccepted), (object) this._socket);
        }

        private void addClient(Socket client)
        {
            string key = AbstractTcpSocket.keyForEndPoint((IPEndPoint) client.RemoteEndPoint);
            this._clients.Add(key, client);
            this._logger.Debug("Server accepted new client connection from " + key);
            this.receive(new ReceiveVO(client, new byte[client.ReceiveBufferSize]));
            if (this.OnClientConnected == null)
                return;
            this.OnClientConnected(this, client);
        }

        protected override void onReceived(IAsyncResult ar)
        {
            ReceiveVO asyncState = (ReceiveVO) ar.AsyncState;
            int bytesReceived = 0;
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
                this.removeClient(asyncState.socket);
            }
            else
            {
                string str = AbstractTcpSocket.keyForEndPoint((IPEndPoint) asyncState.socket.RemoteEndPoint);
                this._logger.Debug("Server received " + (object) bytesReceived + " bytes from " + str);
                this.triggerOnReceived(asyncState, bytesReceived);
                this.receive(asyncState);
            }
        }

        private void removeClient(Socket socket)
        {
            string key = this._clients.Single<KeyValuePair<string, Socket>>((Func<KeyValuePair<string, Socket>, bool>) (kv => kv.Value == socket)).Key;
            this._clients.Remove(key);
            socket.Close();
            this._logger.Debug("Client " + key + " disconnected from server");
            if (this.OnClientDisconnected == null)
                return;
            this.OnClientDisconnected(this, socket);
        }

        private void onDisconnectClient(IAsyncResult ar)
        {
            Socket client = (Socket) ar.AsyncState;
            string key = this._clients.Single<KeyValuePair<string, Socket>>((Func<KeyValuePair<string, Socket>, bool>) (kv => kv.Value == client)).Key;
            this._clients.Remove(key);
            client.EndDisconnect(ar);
            client.Close();
            this._logger.Debug("Server disconnected client " + key);
        }

        public delegate void TcpServerSocketHandler(TcpServerSocket server, Socket client);
    }
}