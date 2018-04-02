using GateServerLib.Servers;

namespace GateServerLib
{
    public partial class Api
    {
        private WorldServerMgr _worldServerMgr;
        public WorldServerMgr WorldServerMgr { get => _worldServerMgr; }

        private WorldManagerServerMgr _worldManagerServerMgr;
        public WorldManagerServerMgr WorldManagerServerMgr { get => _worldManagerServerMgr; }

        private void InitServers()
        {
            InitWorldManagerServerMgr();
            InitWorldServers();
        }

        private void ServersProcess()
        {
            _worldManagerServerMgr.Process();
            _worldServerMgr.Process();
        }

        private void InitWorldServers()
        {
            _worldServerMgr = new WorldServerMgr(this);
            //DataList serverConfig = XmlDataManager.Inst.GetDataList(ServerConfigConst.ServerConfig);
            //string name = ApiTag.GetServerTagString();
            //Data serverData = serverConfig.Get(name);
            //listenport = (ushort)serverData.GetInt("Port");

            //_worldServerMgr.InitConnect("127.0.0.1", 8002);
        }

        private void InitWorldManagerServerMgr()
        {
            _worldManagerServerMgr = new WorldManagerServerMgr(this);
            //_worldManagerServerMgr.InitConnect("127.0.0.1",8002);
        }       
    }
}
