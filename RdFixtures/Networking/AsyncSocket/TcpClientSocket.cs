using System;
using System.Net;
using System.Net.Sockets;

namespace Rd.Networking
{
    public class TcpClientSocket : AbstractTcpSocket
    {
        public delegate void TcpClientSocketHandler(TcpClientSocket client);

        public TcpClientSocket()
            : base(typeof(TcpClientSocket).FullName)
        {
        }

        public bool isConnected => _socket.Connected;

        public event TcpClientSocketHandler OnConnected;

        public event TcpClientSocketHandler OnDisconnected;

        public void Connect(IPAddress ipAddress, int port)
        {
            _logger.Debug("Client is connecting to " + ipAddress + ":" + port + "...");
            _socket.BeginConnect(ipAddress, port, onConnected, _socket);
        }

        public override void Send(byte[] buffer)
        {
            send(_socket, buffer);
        }

        public override void Disconnect()
        {
            _logger.Debug("Client is disconnecting...");
            _socket.Shutdown(SocketShutdown.Both);
            _socket.BeginDisconnect(false, onDisconnected, _socket);
        }

        private void onConnected(IAsyncResult ar)
        {
            var asyncState = (Socket) ar.AsyncState;
            var flag = false;
            try
            {
                asyncState.EndConnect(ar);
                flag = true;
            }
            catch (SocketException ex)
            {
                _logger.Error(ex.Message);
            }

            if (!flag)
                return;
            _logger.Debug("Client connected to " + keyForEndPoint((IPEndPoint) asyncState.RemoteEndPoint));
            receive(new ReceiveVO(asyncState, new byte[asyncState.ReceiveBufferSize]));
            if (OnConnected == null)
                return;
            OnConnected(this);
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
                disconnectedByRemote(asyncState.socket);
            }
            else
            {
                var str = keyForEndPoint((IPEndPoint) asyncState.socket.RemoteEndPoint);
                _logger.Debug("Client received " + bytesReceived + " bytes from " + str);
                triggerOnReceived(asyncState, bytesReceived);
                receive(asyncState);
            }
        }

        private void disconnectedByRemote(Socket client)
        {
            client.Close();
            _logger.Info("Client got disconnected by remote");
            if (OnDisconnected == null)
                return;
            OnDisconnected(this);
        }

        private void onDisconnected(IAsyncResult ar)
        {
            var asyncState = (Socket) ar.AsyncState;
            asyncState.EndDisconnect(ar);
            asyncState.Close();
            _logger.Debug("Client disconnected");
            if (OnDisconnected == null)
                return;
            OnDisconnected(this);
        }
    }
}