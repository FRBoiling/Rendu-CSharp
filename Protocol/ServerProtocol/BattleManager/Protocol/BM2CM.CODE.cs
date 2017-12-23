using System;
namespace Message.BattleManager.ClusterManager.Protocol.BM2CM {

	public partial class MSG_BM2CM_HEARTBEAT {}
	public partial class MSG_BM2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.BattleManager.ClusterManager.Protocol.BM2CM.MSG_BM2CM_HEARTBEAT>.Value = 0x51000001;
			Engine.Foundation.Id<Message.BattleManager.ClusterManager.Protocol.BM2CM.MSG_BM2CM_REGISTER>.Value = 0x51000002;
		}
	}

}
namespace BattleManager.ClusterManager.Protocol {
	partial class BM2CM {
		static public void GenerateId() {
			Engine.Foundation.Id<BattleManager.ClusterManager.Protocol.BM2CM>.Value = 0x51000000;
		}
	}
}
