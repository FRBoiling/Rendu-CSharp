
using System.Collections.Generic;

namespace BattleManagerServerLib
{
    public class BattleServerManager
    {
        private Api _api = null;

        public Api Api
        {
            get { return _api; }
            set { _api = value; }
        }

        public BattleServerManager(Api api)
        {
            _api = api;
        }

        public List<BattleServer> _allBattles = new List<BattleServer>();
    }
}