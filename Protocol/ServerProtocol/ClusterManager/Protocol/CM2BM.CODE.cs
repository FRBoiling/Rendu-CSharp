using System;
namespace Message.Server.ClusterManager.Protocol.CM2BM {

	public partial class MSG_CM2BM_HEARTBEAT {}
	public partial class MSG_CM2BM_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Server.ClusterManager.Protocol.CM2BM.MSG_CM2BM_HEARTBEAT>.Value = 0x01020001;
			Engine.Foundation.Id<Message.Server.ClusterManager.Protocol.CM2BM.MSG_CM2BM_RETRUN_REGISTER>.Value = 0x01020002;
		}
	}

}
namespace Server.ClusterManager.Protocol {
	partial class CM2BM {
		static public void GenerateId() {
			Engine.Foundation.Id<Server.ClusterManager.Protocol.CM2BM>.Value = 0x01020000;
		}
	}
}
