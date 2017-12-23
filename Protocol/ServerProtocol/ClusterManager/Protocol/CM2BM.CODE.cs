using System;
namespace Message.ClusterManager.BattleManager.Protocol.CM2BM {

	public partial class MSG_CM2BM_HEARTBEAT {}
	public partial class MSG_CM2BM_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.ClusterManager.BattleManager.Protocol.CM2BM.MSG_CM2BM_HEARTBEAT>.Value = 0x15000001;
			Engine.Foundation.Id<Message.ClusterManager.BattleManager.Protocol.CM2BM.MSG_CM2BM_RETRUN_REGISTER>.Value = 0x15000002;
		}
	}

}
namespace ClusterManager.BattleManager.Protocol {
	partial class CM2BM {
		static public void GenerateId() {
			Engine.Foundation.Id<ClusterManager.BattleManager.Protocol.CM2BM>.Value = 0x15000000;
		}
	}
}
