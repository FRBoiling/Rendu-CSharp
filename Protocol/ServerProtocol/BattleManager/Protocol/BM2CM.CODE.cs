using System;
namespace Message.Server.BattleManager.Protocol.BM2CM {

	public partial class MSG_BM2CM_HEARTBEAT {}
	public partial class MSG_BM2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Server.BattleManager.Protocol.BM2CM.MSG_BM2CM_HEARTBEAT>.Value = 0x02010001;
			Engine.Foundation.Id<Message.Server.BattleManager.Protocol.BM2CM.MSG_BM2CM_REGISTER>.Value = 0x02010002;
		}
	}

}
namespace Server.BattleManager.Protocol {
	partial class BM2CM {
		static public void GenerateId() {
			Engine.Foundation.Id<Server.BattleManager.Protocol.BM2CM>.Value = 0x02010000;
		}
	}
}
