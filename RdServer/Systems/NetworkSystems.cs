using AppFrame;
using Entitas;
using Entitas.Collector;
using Entitas.Context;
using Microsoft.IO;
using Rd.Networking;
using Rd.Networking.IOCP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class NetworkReactiveSystem : ReactiveSystem<NetworkEntity>
    {
        Contexts _contexts;
        public NetworkReactiveSystem(Contexts contexts) : base(contexts.network)
        {
            _contexts = contexts;
        }
        protected override bool Filter(NetworkEntity entity)
        {
            return entity.hasNetwork;
        }

        protected override ICollector<NetworkEntity> GetTrigger(IContext<NetworkEntity> context)
        {
            return context.CreateCollector(NetworkMatcher.Network);
        }
        protected override void Execute(List<NetworkEntity> entities)
        {
            foreach (var e in entities)
            {
                switch (e.network.NetworkType)
                {
                    case NetworkType.Default:
                        break;
                    case NetworkType.TCP:
                        e.AddNetworkService(new TcpService(e.network.ChannelType,e.network.SessionType, e.network.IpEndPoint,OnConnect, MainThreadSynchronizationContext.Inst));
                        break;
                    case NetworkType.Http:
                        break;
                    default:
                        break;
                }

            }
        }

        private void OnConnect(AChannel channel)
        {
            Console.WriteLine($"connection success! {channel.ToString()}");
            SessionEntity session = _contexts.session.CreateEntity();
            session.AddChannel(channel);
            session.isOffline = false;
        }
    }

    public class NetworkSystems : IInitializeSystem, IExecuteSystem
    {
        readonly NetworkContext _context;
        public NetworkSystems(Contexts contexts)
        {
            _context = contexts.network;
        }

        public void Initialize()
        {
            var entity1 = _context.CreateEntity();
            entity1.AddNetwork(NetworkType.TCP, ChannelType.Accept, SessionType.Client, new IPEndPoint(IPAddress.Any, 50000));
        }

        public void Execute()
        {
            foreach (var e in _context.GetEntities())
            {
                e.networkService.Service?.Update();
            }
        }
    }


}
