using ClusterManagerServerLib.Server;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib
{
    public partial class Api
    {
        private BattleServerMgr _battleServerMgr;
        public BattleServerMgr BattleServerMgr { get => _battleServerMgr; }


        private BattleManagerServerMgr _battleManagerServerMgr;
        public BattleManagerServerMgr BattleManagerServerMgr { get => _battleManagerServerMgr; }

        private WorldServerMgr _worldServerMgr;
        public WorldServerMgr WorldServerMgr { get => _worldServerMgr; }


        private WorldManagerServerMgr _worldManagerServerMgr;
        public WorldManagerServerMgr WorldManagerServerMgr { get => _worldManagerServerMgr; }

        //
        public ushort listenPortBattle;
        public ushort listenPortBattleManager;

        public ushort listenPortWorld;
        public ushort listenPortWorldManager;

        private void InitServers()
        {
            InitBattleServers();
            InitBattleManagerServer();
            InitWorldServers();
            InitWorldManagerServer();
        }

        private void InitBattleServers()
        {
            listenPortBattle = 8505;

            _battleServerMgr = new BattleServerMgr(this);
            _battleServerMgr.Bind(listenPortBattle,2);
            _battleServerMgr.Listen(listenPortBattle);
        }

        private void InitBattleManagerServer()
        {
            listenPortBattleManager = 8506;

            _battleManagerServerMgr = new BattleManagerServerMgr(this);
            _battleManagerServerMgr.Bind(listenPortBattle, 2);
            _battleManagerServerMgr.Listen(listenPortBattle);
        }


        private void InitWorldServers()
        {
            listenPortWorld = 8505;

            _worldServerMgr = new WorldServerMgr(this);
            _worldServerMgr.Bind(listenPortWorld, 2);
            _worldServerMgr.Listen(listenPortWorld);
        }

        private void InitWorldManagerServer()
        {
            listenPortWorldManager = 8505;

            _worldManagerServerMgr = new WorldManagerServerMgr(this);
            _worldManagerServerMgr.Bind(listenPortWorldManager, 2);
            _worldManagerServerMgr.Listen(listenPortWorldManager);
        }

        private void UpdateServers()
        {
            _battleServerMgr.UpdateServers();
            _battleManagerServerMgr.UpdateServers();
            _worldServerMgr.UpdateServers();
            _worldManagerServerMgr.UpdateServers();
        }
    }
}
