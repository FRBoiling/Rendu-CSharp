using System;
using System.Net;
using System.Net.Sockets;
using Rd.Logging;

namespace Rd.Networking
{
    public abstract class AbstractTcpSocket
    {
        protected readonly Logger _logger;
        protected readonly Socket _socket;

        protected AbstractTcpSocket(string loggerName)
        {
            _logger = fabl.GetLogger(loggerName);
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public event TcpSocketReceive OnReceived;

        public abstract void Send(byte[] buffer);

        protected void send(Socket socket, byte[] buffer)
        {
            var str = keyForEndPoint((IPEndPoint) socket.RemoteEndPoint);
            _logger.Debug("Sending " + buffer.Length + " bytes via " + str);
            socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, onSent, socket);
        }

        private void onSent(IAsyncResult ar)
        {
            var asyncState = (Socket) ar.AsyncState;
            try
            {
                asyncState.EndSend(ar);
            }
            catch (ObjectDisposedException ex)
            {
            }
        }

        protected void receive(ReceiveVO receiveVO)
        {
            receiveVO.socket.BeginReceive(receiveVO.bytes, 0, receiveVO.bytes.Length, SocketFlags.None, onReceived, receiveVO);
        }

        protected abstract void onReceived(IAsyncResult ar);

        public abstract void Disconnect();

        protected void triggerOnReceived(ReceiveVO receiveVO, int bytesReceived)
        {
            if (OnReceived == null)
                return;
            OnReceived(this, receiveVO.socket, trimmedBytes(receiveVO.bytes, bytesReceived));
        }

        protected static string keyForEndPoint(IPEndPoint endPoint)
        {
            return endPoint.Address + ":" + endPoint.Port;
        }

        private static byte[] trimmedBytes(byte[] bytes, int length)
        {
            var numArray = new byte[length];
            Array.Copy(bytes, numArray, length);
            return numArray;
        }
    }
}