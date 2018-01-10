using ClusterManagerServerLib.Server;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib
{
    public partial class Api
    {
        private BattleServerMgr _battleServerMgr;

        public BattleServerMgr BattleServerMgr { get => _battleServerMgr; }

        //
        public ushort listenPortBattle;

        private void InitServers()
        {
            InitBattleServers();
        }

        private void InitBattleServers()
        {
            listenPortBattle = 8505;

            _battleServerMgr = new BattleServerMgr(this);
            _battleServerMgr.Bind(listenPortBattle,2);
            _battleServerMgr.Listen(listenPortBattle);
        }


        private void UpdateServers()
        {
            _battleServerMgr.UpdateServers();
        }
    }
}
