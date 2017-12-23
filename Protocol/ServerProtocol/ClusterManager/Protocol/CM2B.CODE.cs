using System;
namespace Message.ClusterManager.Battle.Protocol.CM2B {

	public partial class MSG_CM2B_HEARTBEAT {}
	public partial class MSG_CM2B_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.ClusterManager.Battle.Protocol.CM2B.MSG_CM2B_HEARTBEAT>.Value = 0x16000001;
			Engine.Foundation.Id<Message.ClusterManager.Battle.Protocol.CM2B.MSG_CM2B_RETRUN_REGISTER>.Value = 0x16000002;
		}
	}

}
namespace ClusterManager.Battle.Protocol {
	partial class CM2B {
		static public void GenerateId() {
			Engine.Foundation.Id<ClusterManager.Battle.Protocol.CM2B>.Value = 0x16000000;
		}
	}
}
