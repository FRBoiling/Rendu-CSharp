using System;
namespace Message.Server.ClusterManager.Protocol.CM2B {

	public partial class MSG_CM2B_HEARTBEAT {}
	public partial class MSG_CM2B_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Server.ClusterManager.Protocol.CM2B.MSG_CM2B_HEARTBEAT>.Value = 0x01030001;
			Engine.Foundation.Id<Message.Server.ClusterManager.Protocol.CM2B.MSG_CM2B_RETRUN_REGISTER>.Value = 0x01030002;
		}
	}

}
namespace Server.ClusterManager.Protocol {
	partial class CM2B {
		static public void GenerateId() {
			Engine.Foundation.Id<Server.ClusterManager.Protocol.CM2B>.Value = 0x01030000;
		}
	}
}
