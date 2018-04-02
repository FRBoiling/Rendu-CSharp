using ServerFrameWork;
using System;
using TcpLib;

namespace GateServerLib.Servers
{
    public class WorldServer : AbstractTcpClient
    {
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
        {
            get { return _tag; }
        }

        private WorldServerMgr _manager;

        public WorldServer(WorldServerMgr manager, string ip, ushort port)
            : base(ip, port)
        {
            _manager = manager;
            _tag.Type = ServerType.World;
        }

        protected override void BindResponser()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectedComplete()
        {
            throw new NotImplementedException();
        }

        protected override void DisconnectComplete()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessLogic()
        {
            throw new NotImplementedException();
        }

        protected override void ReConnectedComplete()
        {
            throw new NotImplementedException();
        }
    }
}
