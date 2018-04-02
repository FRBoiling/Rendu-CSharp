using DataParserLib;
using ServerFrameWork;

namespace WorldManagerServerLib
{
    public partial class Api
    {
        private WorldServerMgr _worldServerMgr;
        public WorldServerMgr WorldServerMgr { get => _worldServerMgr; }


        private void InitServers()
        {
            InitWorldServers();
        }

        private void InitWorldServers()
        {
            _worldServerMgr = new WorldServerMgr(this);
            _worldServerMgr.Bind(listenport, 3);
            _worldServerMgr.Listen(listenport);
        }

        private void UpdateServers()
        {
            _worldServerMgr.Process();
        }
    }
}
