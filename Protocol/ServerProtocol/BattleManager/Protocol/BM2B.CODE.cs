using System;
namespace Message.BattleManager.Battle.Protocol.BM2B {

	public partial class MSG_BM2B_HEARTBEAT {}
	public partial class MSG_BM2B_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.BattleManager.Battle.Protocol.BM2B.MSG_BM2B_HEARTBEAT>.Value = 0x56000001;
			Engine.Foundation.Id<Message.BattleManager.Battle.Protocol.BM2B.MSG_BM2B_RETRUN_REGISTER>.Value = 0x56000002;
		}
	}

}
namespace BattleManager.Battle.Protocol.BM2B {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<BattleManager.Battle.Protocol.BM2B.Provider>.Value = 0x56000000;
		}
	}
}
