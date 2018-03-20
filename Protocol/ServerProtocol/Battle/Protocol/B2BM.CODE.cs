using System;
namespace Message.Battle.BattleManager.Protocol.B2BM {

	public partial class MSG_B2BM_HEARTBEAT {}
	public partial class MSG_B2BM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Battle.BattleManager.Protocol.B2BM.MSG_B2BM_HEARTBEAT>.Value = 0x65000001;
			Engine.Foundation.Id<Message.Battle.BattleManager.Protocol.B2BM.MSG_B2BM_REGISTER>.Value = 0x65000002;
		}
	}

}
namespace Battle.BattleManager.Protocol.B2BM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Battle.BattleManager.Protocol.B2BM.Provider>.Value = 0x65000000;
		}
	}
}
