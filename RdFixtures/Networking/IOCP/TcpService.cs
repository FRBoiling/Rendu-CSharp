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

    public class TcpService : AService
    {
        private static readonly Logger _logger = fabl.GetLogger(typeof(TcpService));

        public NetworkType NetworkType = NetworkType.TCP;
        public ChannelType ChannelType;

        private readonly Dictionary<long, TcpChannel> _idChannels;

        protected Socket _socket;

        protected readonly SocketAsyncEventArgs _eventArgs;

        private readonly HashSet<long> _needStartSendChannel;

        private SynchronizationContext _synchronizationContext;


        public TcpService(ChannelType channelType,SessionType sessionType, IPEndPoint ipEndPoint, Action<AChannel> callback, SynchronizationContext synchronizationContext) : base(callback)
        {
            ChannelType = channelType;
            Packer = MessagePackerFactory.Create(sessionType);

            _synchronizationContext = synchronizationContext;

            _idChannels = new Dictionary<long, TcpChannel>();
            _needStartSendChannel = new HashSet<long>();

            _eventArgs = new SocketAsyncEventArgs();
            _eventArgs.Completed += OnComplete;

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            switch (ChannelType)
            {
                case ChannelType.Connect:
                    _eventArgs.RemoteEndPoint = ipEndPoint;
                    ConnectAsync();
                    break;
                case ChannelType.Accept:
                    _socket.Bind(ipEndPoint);
                    _socket.Listen(1000);
                    AcceptAsync();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ChannelType), ChannelType, null);
            }
        }

        private void OnComplete(object sender, SocketAsyncEventArgs eventArgs)
        {
            switch (eventArgs.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    _synchronizationContext.Post(OnConnectComplete, eventArgs);
                    break;
                case SocketAsyncOperation.Accept:
                    _synchronizationContext.Post(OnAcceptComplete, eventArgs);
                    break;
                default:
                    throw new Exception($"socket connect error: {eventArgs.LastOperation}");
            }
        }

        private void AcceptAsync()
        {
            _logger.Debug($"accept on {_socket.LocalEndPoint}");
            _eventArgs.AcceptSocket = null;
            if (_socket.AcceptAsync(_eventArgs))
            {
                return;
            }

            OnAcceptComplete(_eventArgs);
        }

        private void OnAcceptComplete(object o)
        {
            if (_socket == null)
            {
                return;
            }

            var eventArgs = (SocketAsyncEventArgs)o;

            if (eventArgs.SocketError != SocketError.Success)
            {
                _logger.Error($"accept error {eventArgs.SocketError}");
                AcceptAsync();
                return;
            }

            var channel = new TcpChannel(this,  ChannelType.Accept, eventArgs.AcceptSocket, _synchronizationContext);
            channel.Id = GenerateChannelId();

            _idChannels[channel.Id] = channel;

            try
            {
                OnAction(channel);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            if (_socket == null)
            {
                return;
            }

            AcceptAsync();
        }

        long maxId = 0;
        private long GenerateChannelId()
        {
            ++maxId;
            if (maxId > 0xfffffff)
            {
                maxId = 0;
            }

            return maxId;
        }

        public void MarkNeedStartSend(long id)
        {
            _needStartSendChannel.Add(id);
        }

        private void ConnectAsync()
        {
            _logger.Debug($"try to connect to {_eventArgs.RemoteEndPoint}");
            if (_socket.ConnectAsync(_eventArgs))
            {
                return;
            }

            OnConnectComplete(_eventArgs);
        }

        private void OnConnectComplete(object o)
        {
            if (_socket == null)
            {
                return;
            }

            var eventArgs = (SocketAsyncEventArgs)o;

            if (eventArgs.SocketError != SocketError.Success)
            {
                //重连
                _logger.Error($"connect error : {eventArgs.SocketError},try to reconnect to {eventArgs.RemoteEndPoint}");
                ConnectAsync();
                return;
            }

            var channel = new TcpChannel(this,  ChannelType.Connect, eventArgs.ConnectSocket, _synchronizationContext);
            _idChannels[channel.Id] = channel;
            
            try
            {
                OnAction(channel);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }


        public void ReconnectAsync()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            ConnectAsync();
        }


        public override AChannel GetChannel(long id)
        {
            _idChannels.TryGetValue(id, out var channel);
            return channel; 
        }

        public override void Remove(long channelId)
        {
            if (!_idChannels.TryGetValue(channelId, out var channel))
            {
                return;
            }
            if (channel == null)
            {
                return;
            }
            _idChannels.Remove(channelId);
        }

        public override void Update()
        {
            foreach (var id in _needStartSendChannel)
            {
                if (!_idChannels.TryGetValue(id, out var channel))
                {
                    continue;
                }

                if (channel.IsSending)
                {
                    continue;
                }

                try
                {
                    channel.StartSend();
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                }
            }

            _needStartSendChannel.Clear();
        }


        public void Dispose()
        {
            _logger.Debug("TcpService dispose");

            if (IsDisposed)
            {
                return;
            }

            foreach (var id in _idChannels.Keys)
            {
                var channel = _idChannels[id];
                channel.Dispose();
            }
            _socket?.Close();
            _socket = null;
            _eventArgs.Dispose();
        }

        //public override object DeserializeFrom(object obj, MemoryStream memoryStream)
        //{
        //    return Packer.DeserializeFrom(obj, memoryStream);
        //}
    }
}
