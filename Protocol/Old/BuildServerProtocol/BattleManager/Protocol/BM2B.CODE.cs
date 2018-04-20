using System;
namespace Protocol.BattleManager.BM2B {

	public partial class MSG_BM2B_HEARTBEAT {}
	public partial class MSG_BM2B_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.BattleManager.BM2B.MSG_BM2B_HEARTBEAT>.Value = 0x5600001;
			Engine.Foundation.Id<Protocol.BattleManager.BM2B.MSG_BM2B_RETRUN_REGISTER>.Value = 0x5600002;
		}
	}

}
