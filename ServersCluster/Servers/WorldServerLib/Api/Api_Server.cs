namespace WorldServerLib
{
    public partial class Api
    {
        private WorldManagerServer _worldManagerServer;
        public WorldManagerServer WorldManagerServer { get => _worldManagerServer; }

        //
        //public ushort listenPortBattle;
        //public ushort listenPortBattleManager;

        //private BattleServerMgr _battleServerMgr;
        //public BattleServerMgr BattleServerMgr { get => _battleServerMgr; }

        //private BattleManagerServerMgr _battleManagerServerMgr;
        //public BattleManagerServerMgr BattleManagerServerMgr { get => _battleManagerServerMgr; }

        private void InitServers()
        {
            InitWorldManagerServer();
            //InitBattleServers();
            //InitBattleManagerServer();
            //InitWorldServers();
        }

        //private void InitBattleServers()
        //{
        //    listenPortBattle = 8505;

        //    _battleServerMgr = new BattleServerMgr(this);
        //    _battleServerMgr.Bind(listenPortBattle,2);
        //    _battleServerMgr.Listen(listenPortBattle);
        //}

        //private void InitBattleManagerServer()
        //{
        //    listenPortBattleManager = 8506;

        //    _battleManagerServerMgr = new BattleManagerServerMgr(this);
        //    _battleManagerServerMgr.Bind(listenPortBattle, 2);
        //    _battleManagerServerMgr.Listen(listenPortBattle);
        //}


        //private void InitWorldServers()
        //{
        //    listenPortWorld = 8505;

        //    _worldServerMgr = new WorldServerMgr(this);
        //    _worldServerMgr.Bind(listenPortWorld, 2);
        //    _worldServerMgr.Listen(listenPortWorld);
        //}

        private void InitWorldManagerServer()
        {
            _worldManagerServer = new WorldManagerServer(this, "127.0.0.1", 8303);
            _worldManagerServer.Connect();
        }

        private void UpdateServers()
        {
            _worldManagerServer.Update();
            //_battleServerMgr.UpdateServers();
            //_battleManagerServerMgr.UpdateServers();
            //_worldServerMgr.UpdateServers();
        }
    }
}
