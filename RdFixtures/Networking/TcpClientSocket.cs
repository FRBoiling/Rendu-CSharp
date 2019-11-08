using System;
using System.Net;
using System.Net.Sockets;

namespace Rd.Networking
{
    public class TcpClientSocket : AbstractTcpSocket
    {
        public event TcpClientSocket.TcpClientSocketHandler OnConnected;

        public event TcpClientSocket.TcpClientSocketHandler OnDisconnected;

        public bool isConnected
        {
            get { return this._socket.Connected; }
        }

        public TcpClientSocket()
            : base(typeof(TcpClientSocket).FullName)
        {
        }

        public void Connect(IPAddress ipAddress, int port)
        {
            this._logger.Debug("Client is connecting to " + (object) ipAddress + ":" + (object) port + "...");
            this._socket.BeginConnect(ipAddress, port, new AsyncCallback(this.onConnected), (object) this._socket);
        }

        public override void Send(byte[] buffer)
        {
            this.send(this._socket, buffer);
        }

        public override void Disconnect()
        {
            this._logger.Debug("Client is disconnecting...");
            this._socket.Shutdown(SocketShutdown.Both);
            this._socket.BeginDisconnect(false, new AsyncCallback(this.onDisconnected), (object) this._socket);
        }

        private void onConnected(IAsyncResult ar)
        {
            Socket asyncState = (Socket) ar.AsyncState;
            bool flag = false;
            try
            {
                asyncState.EndConnect(ar);
                flag = true;
            }
            catch (SocketException ex)
            {
                this._logger.Error(ex.Message);
            }

            if (!flag)
                return;
            this._logger.Debug("Client connected to " + AbstractTcpSocket.keyForEndPoint((IPEndPoint) asyncState.RemoteEndPoint));
            this.receive(new ReceiveVO(asyncState, new byte[asyncState.ReceiveBufferSize]));
            if (this.OnConnected == null)
                return;
            this.OnConnected(this);
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
                this.disconnectedByRemote(asyncState.socket);
            }
            else
            {
                string str = AbstractTcpSocket.keyForEndPoint((IPEndPoint) asyncState.socket.RemoteEndPoint);
                this._logger.Debug("Client received " + (object) bytesReceived + " bytes from " + str);
                this.triggerOnReceived(asyncState, bytesReceived);
                this.receive(asyncState);
            }
        }

        private void disconnectedByRemote(Socket client)
        {
            client.Close();
            this._logger.Info("Client got disconnected by remote");
            if (this.OnDisconnected == null)
                return;
            this.OnDisconnected(this);
        }

        private void onDisconnected(IAsyncResult ar)
        {
            Socket asyncState = (Socket) ar.AsyncState;
            asyncState.EndDisconnect(ar);
            asyncState.Close();
            this._logger.Debug("Client disconnected");
            if (this.OnDisconnected == null)
                return;
            this.OnDisconnected(this);
        }

        public delegate void TcpClientSocketHandler(TcpClientSocket client);
    }
}