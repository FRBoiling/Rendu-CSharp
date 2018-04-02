using LogLib;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpLib;

namespace GateServerLib.Servers
{
    public class WorldManagerServer : AbstractTcpClient
    {
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
        {
            get { return _tag; }
        }

        private WorldManagerServerMgr _manager;

        public WorldManagerServer(WorldManagerServerMgr manager,string ip, ushort port)
            : base(ip,port)
        {
            _manager = manager;
            _tag.Type = ServerType.WorldManager;
        }

        protected override void BindResponser()
        {
            throw new NotImplementedException();
        }

        protected override void ConnectedComplete()
        {
            Log.Info("{0} server connected", Tag.Type);
            _manager.AddConnectedServer(this);
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
