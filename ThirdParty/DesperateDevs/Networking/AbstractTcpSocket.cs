using DesperateDevs.Logging;
using System;
using System.Net;
using System.Net.Sockets;

namespace DesperateDevs.Networking
{
    public abstract class AbstractTcpSocket
    {
        protected readonly Logger _logger;
        protected readonly Socket _socket;

        public event TcpSocketReceive OnReceived;

        protected AbstractTcpSocket(string loggerName)
        {
            this._logger = fabl.GetLogger(loggerName);
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public abstract void Send(byte[] buffer);

        protected void send(Socket socket, byte[] buffer)
        {
            string str = AbstractTcpSocket.keyForEndPoint((IPEndPoint) socket.RemoteEndPoint);
            this._logger.Debug("Sending " + (object) buffer.Length + " bytes via " + str);
            socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(this.onSent), (object) socket);
        }

        private void onSent(IAsyncResult ar)
        {
            Socket asyncState = (Socket) ar.AsyncState;
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
            receiveVO.socket.BeginReceive(receiveVO.bytes, 0, receiveVO.bytes.Length, SocketFlags.None, new AsyncCallback(this.onReceived), (object) receiveVO);
        }

        protected abstract void onReceived(IAsyncResult ar);

        public abstract void Disconnect();

        protected void triggerOnReceived(ReceiveVO receiveVO, int bytesReceived)
        {
            if (this.OnReceived == null)
                return;
            this.OnReceived(this, receiveVO.socket, AbstractTcpSocket.trimmedBytes(receiveVO.bytes, bytesReceived));
        }

        protected static string keyForEndPoint(IPEndPoint endPoint)
        {
            return endPoint.Address.ToString() + ":" + (object) endPoint.Port;
        }

        private static byte[] trimmedBytes(byte[] bytes, int length)
        {
            byte[] numArray = new byte[length];
            Array.Copy((Array) bytes, (Array) numArray, length);
            return numArray;
        }
    }
}