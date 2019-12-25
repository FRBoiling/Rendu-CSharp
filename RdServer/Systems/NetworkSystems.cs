//using AppFrame;
//using Entitas;
//using Entitas.Collector;
//using Entitas.Context;
//using Microsoft.IO;
//using System;
//using System.Collections.Generic;
//using System.Net.Sockets;

//namespace Server
//{
//    public class ConnectorReactiveSystem : ReactiveSystem<NetworkEntity>
//    {
//        Contexts _contexts;
//        public ConnectorReactiveSystem(Contexts contexts) : base(contexts.network)
//        {
//            _contexts = contexts;
//        }
//        protected override bool Filter(NetworkEntity entity)
//        {
//            return entity.hasConnector;
//        }

//        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
//        {
//            return context.CreateCollector(NetworkMatcher.Connector);
//        }
//        protected override void Execute(List<NetworkEntity> entities)
//        {
//            foreach (var e in entities)
//            {
//                if (e.connector.Reconnect)
//                {
//                    // 重连
                  

//                }
//                else
//                {
//                    // 连接
//                    e.ReplaceService(
//                        NetworkType.TCP,
//                        ChannelType.Connector,
//                        new RecyclableMemoryStreamManager(),
//                        new SocketAsyncEventArgs(),
//                        new HashSet<long>(),
//                        new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp));
//                }

//            }
//        }
//    }

//    public class ServiceReactiveSystem : ReactiveSystem<NetworkEntity>
//    {
//        Contexts _contexts;
//        public ServiceReactiveSystem(Contexts contexts) : base(contexts.network)
//        {
//            _contexts = contexts;
//        }

//        protected override bool Filter(NetworkEntity entity)
//        {
//            return entity.hasService;
//        }

//        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
//        {
//            return context.CreateCollector(NetworkMatcher.Service);
//        }

//        protected override void Execute(List<NetworkEntity> entities)
//        {
//            foreach (var e in entities)
//            {
//                e.service.EventArgs.Completed += OnComplete;
//                e.service.Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
//                ChannelType type = e.service.ChannelType;
//                switch (type)
//                {
//                    case ChannelType.Connector:
//                        e.service.EventArgs.RemoteEndPoint = e.connector.RemoteEndPoint;
//                        ConnectAsync(e.service);
//                        break;
//                    case ChannelType.Listener:
//                        e.service.Socket.Bind(e.listener.LocalEndPoint);
//                        e.service.Socket.Listen(1000);
//                        AcceptAsync(e.service);
//                        break;
//                    default:
//                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
//                }
//            }
//        }

//        private void AcceptAsync(ServiceComponent service)
//        {
//            //Log.Debug($"accept on {_socket.LocalEndPoint}");
//            service.EventArgs.AcceptSocket = null;
//            if (service.Socket.AcceptAsync(service.EventArgs))
//            {
//                return;
//            }

//            OnAcceptComplete(service.EventArgs);
//        }

//        private void ConnectAsync(ServiceComponent service)
//        {
//            //Log.Debug($"try to connect to {_eventArgs.RemoteEndPoint}");
//            if (service.Socket.ConnectAsync(service.EventArgs))
//            {
//                return;
//            }

//            OnConnectComplete(service.EventArgs);
//        }

//        private void OnComplete(object sender, SocketAsyncEventArgs eventArgs)
//        {
//            switch (eventArgs.LastOperation)
//            {
//                case SocketAsyncOperation.Connect:
//                    MainThreadSynchronizationContext.Inst.Post(OnConnectComplete, eventArgs);
//                    break;
//                case SocketAsyncOperation.Accept:
//                    MainThreadSynchronizationContext.Inst.Post(OnAcceptComplete, eventArgs);
//                    break;
//                default:
//                    throw new Exception($"socket connect error: {eventArgs.LastOperation}");
//            }
//        }

//        private void OnAcceptComplete(object state)
//        {
//            var eventArgs = (SocketAsyncEventArgs)state;

//            if (eventArgs.SocketError != SocketError.Success)
//            {
//                //Log.Error($"accept error {e.SocketError}");
//                foreach (var e in _contexts.network.GetEntities())
//                {
//                    e.ReplaceListener(e.listener.LocalEndPoint, true);
//                }
//                return;
//            }


//            foreach (var e in _contexts.network.GetEntities())
//            {
//                e.AddChannal(eventArgs.AcceptSocket);
//            }

//            var channel = new TcpChannel(this, eventArgs.AcceptSocket, ChannelType.Accept);
//            _idChannels[channel.Id] = channel;

//            try
//            {
//                OnAction(channel);
//            }
//            catch (Exception exception)
//            {
//                Log.Error(exception);
//            }

//            if (_socket == null)
//            {
//                return;
//            }

//            AcceptAsync();
//        }

//        private void OnConnectComplete(object state)
//        {
//            if (_socket == null)
//            {
//                return;
//            }

//            var e = (SocketAsyncEventArgs)o;

//            if (e.SocketError != SocketError.Success)
//            {
//                //重连
//                Log.Error($"connect error : {e.SocketError},try to reconnect to {e.RemoteEndPoint}");
//                ConnectAsync();
//                return;
//            }

//            var channel = new TcpChannel(this, e.ConnectSocket, ChannelType.Connect);
//            _idChannels[channel.Id] = channel;

//            try
//            {
//                OnAction(channel);
//            }
//            catch (Exception exception)
//            {
//                Log.Error(exception);
//            }
//        }


//    }
//}
