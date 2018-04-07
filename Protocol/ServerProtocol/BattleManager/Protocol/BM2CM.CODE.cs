using System;
namespace Protocol.BattleManager.BM2CM {

	public partial class MSG_BM2CM_HEARTBEAT {}
	public partial class MSG_BM2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.BattleManager.BM2CM.MSG_BM2CM_HEARTBEAT>.Value = 0x5100001;
			Engine.Foundation.Id<Protocol.BattleManager.BM2CM.MSG_BM2CM_REGISTER>.Value = 0x5100002;
		}
	}

}
