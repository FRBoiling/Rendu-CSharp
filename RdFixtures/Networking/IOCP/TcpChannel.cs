using Rd.Buffer;
using Rd.Helper;
using Rd.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Rd.Networking.IOCP
{
    public class TcpChannel : AChannel
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(TcpChannel));

        private Socket _socket;
        private SocketAsyncEventArgs _writeArgs = new SocketAsyncEventArgs();
        private SocketAsyncEventArgs _readArgs = new SocketAsyncEventArgs();

        private readonly CircularBuffer _sendBuffer = new CircularBuffer();
        private readonly CircularBuffer _recvBuffer = new CircularBuffer();

        private MemoryStream _memoryStream;


        private bool isSending;
        public bool IsSending { get { return isSending; } }

        private bool isRecving;
        public bool IsRecving { get { return isRecving; } }

        private bool isConnected;

        private PacketParser _parser;

        private byte[] packetSizeCache;

        private SynchronizationContext _synchronizationContext;

        public TcpChannel(TcpService service, ChannelType channelType, Socket socket, SynchronizationContext synchronizationContext) : base(service, channelType)
        {
            _synchronizationContext = synchronizationContext;

            int packetSize = service.Packer.GetPacketSize();

            packetSizeCache = new byte[packetSize];
            _memoryStream = Service.MemoryStreamManager.GetStream("message", ushort.MaxValue);
            _parser = new PacketParser(packetSize,service.Packer, _recvBuffer, _memoryStream);

            _writeArgs.Completed += OnIOComplete;
            _readArgs.Completed += OnIOComplete;

            _socket = socket;
            _socket.NoDelay = true;
            RemoteAddress = (IPEndPoint)socket.RemoteEndPoint;
            LocalAddress = (IPEndPoint)socket.LocalEndPoint;

            isSending = false;
            isConnected = true;
        }

        private void OnIOComplete(object sender, SocketAsyncEventArgs eventArgs)
        {
            switch (eventArgs.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    _synchronizationContext.Post(OnRecvComplete, eventArgs);
                    break;
                case SocketAsyncOperation.Send:
                    _synchronizationContext.Post(OnSendComplete, eventArgs);
                    break;
                case SocketAsyncOperation.Disconnect:
                    _synchronizationContext.Post(OnDisconnectComplete, eventArgs);
                    break;
                default:
                    throw new Exception($"socket error: {eventArgs.LastOperation}");
            }
        }

        public override void Send(MemoryStream stream)
        {
            if (this.IsDisposed)
            {
                throw new Exception("TChannel已经被Dispose, 不能发送消息");
            }

            switch (this.GetService().Packer.GetPacketSize())
            {
                case Packet.PacketSizeLength4:
                    if (stream.Length > ushort.MaxValue * 16)
                    {
                        throw new Exception($"send packet too large: {stream.Length}");
                    }
                    this.packetSizeCache.WriteTo(0, (int)stream.Length);
                    break;
                case Packet.PacketSizeLength2:
                    if (stream.Length > ushort.MaxValue)
                    {
                        throw new Exception($"send packet too large: {stream.Length}");
                    }
                    this.packetSizeCache.WriteTo(0, (ushort)stream.Length);
                    break;
                default:
                    throw new Exception("packet size must be 2 or 4!");
            }

            _sendBuffer.Write(this.packetSizeCache, 0, this.packetSizeCache.Length);
            _sendBuffer.Write(stream);

            GetService().MarkNeedStartSend(this.Id);
        }

        public override void Start()
        {
            if (!isRecving)
            {
                isRecving = true;
                StartRecv();
            }
            GetService().MarkNeedStartSend(Id);
        }

        private TcpService GetService()
        {
            return Service as TcpService;
        }

        private void OnRecvComplete(object state)
        {
            if (_socket == null)
            {
                return;
            }

            SocketAsyncEventArgs eventArgs = (SocketAsyncEventArgs)state;

            if (eventArgs.SocketError != SocketError.Success)
            {
                OnError((int)eventArgs.SocketError);
                return;
            }

            if (eventArgs.BytesTransferred == 0)
            {
                OnError(NetworkErrorCode.PeerDisconnect);
                return;
            }

            _recvBuffer.LastIndex += eventArgs.BytesTransferred;
            if (_recvBuffer.LastIndex == _recvBuffer.ChunkSize)
            {
                _recvBuffer.AddLast();
                _recvBuffer.LastIndex = 0;
            }

            // 收到消息回调
            while (true)
            {
                try
                {
                    if (!_parser.Parse())
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    _logger.Error(e.StackTrace);
                    OnError(NetworkErrorCode.SocketError);
                    return;
                }

                try
                {
                    OnRead(_parser.GetPacket());
                }
                catch (Exception e)
                {
                    _logger.Error(e.StackTrace);
                }
            }

            if (_socket == null)
            {
                return;
            }

            StartRecv();
        }

        private void StartRecv()
        {
            int size = _recvBuffer.ChunkSize - _recvBuffer.LastIndex;
            RecvAsync(_recvBuffer.Last, _recvBuffer.LastIndex, size);
        }

        private void RecvAsync(byte[] buffer, int offset, int count)
        {
            try
            {
                _readArgs.SetBuffer(buffer, offset, count);
            }
            catch (Exception e)
            {
                throw new Exception($"socket set buffer error: {buffer.Length}, {offset}, {count}", e);
            }

            if (_socket.ReceiveAsync(_readArgs))
            {
                return;
            }

            OnRecvComplete(_readArgs);
        }


        private void OnSendComplete(object state)
        {
            if (_socket == null)
            {
                return;
            }

            SocketAsyncEventArgs eventArgs = (SocketAsyncEventArgs)state;

            if (eventArgs.SocketError != SocketError.Success)
            {
                OnError((int)eventArgs.SocketError);
                return;
            }

            if (eventArgs.BytesTransferred == 0)
            {
                OnError(NetworkErrorCode.PeerDisconnect);
                return;
            }

            _sendBuffer.FirstIndex += eventArgs.BytesTransferred;
            if (_sendBuffer.FirstIndex == _sendBuffer.ChunkSize)
            {
                _sendBuffer.FirstIndex = 0;
                _sendBuffer.RemoveFirst();
            }

            StartSend();
        }

        public void StartSend()
        {
            if (!isConnected)
            {
                return;
            }

            // 没有数据需要发送
            if (_sendBuffer.Length == 0)
            {
                isSending = false;
                return;
            }

            isSending = true;

            int sendSize = _sendBuffer.ChunkSize - _sendBuffer.FirstIndex;
            if (sendSize > _sendBuffer.Length)
            {
                sendSize = (int)_sendBuffer.Length;
            }

            SendAsync(_sendBuffer.First, _sendBuffer.FirstIndex, sendSize);
        }
        private void SendAsync(byte[] buffer, int offset, int count)
        {
            try
            {
                _writeArgs.SetBuffer(buffer, offset, count);
            }
            catch (Exception e)
            {
                throw new Exception($"socket set buffer error: {buffer.Length}, {offset}, {count}", e);
            }

            if (_socket.SendAsync(_writeArgs))
            {
                return;
            }

            OnSendComplete(_writeArgs);
        }


        private void OnDisconnectComplete(object state)
        {
            SocketAsyncEventArgs eventArgs = (SocketAsyncEventArgs)state;
            OnError((int)eventArgs.SocketError);
        }


        public override void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            base.Dispose();
            _logger.Debug("TcpChannel dispose");

            _socket.Close();
            _writeArgs.Dispose();
            _readArgs.Dispose();
            _writeArgs = null;
            _readArgs = null;
            _socket = null;
            _memoryStream.Dispose();
        }


        public override bool Equals(object obj)
        {
            var channel = obj as TcpChannel;
            return this.Id == channel.Id && this.ChannelType == channel.ChannelType && this.RemoteAddress == channel.RemoteAddress && this.LocalAddress == channel.LocalAddress;
        }

        public override int GetHashCode()
        {
            return 1115863111 + EqualityComparer<Socket>.Default.GetHashCode(_socket);
        }
    }
}
