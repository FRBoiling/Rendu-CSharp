using System;
namespace Message.ClusterManager.WorldManager.Protocol.CM2WM {

	public partial class MSG_CM2WM_HEARTBEAT {}
	public partial class MSG_CM2WM_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.ClusterManager.WorldManager.Protocol.CM2WM.MSG_CM2WM_HEARTBEAT>.Value = 0x13000001;
			Engine.Foundation.Id<Message.ClusterManager.WorldManager.Protocol.CM2WM.MSG_CM2WM_RETRUN_REGISTER>.Value = 0x13000002;
		}
	}

}
namespace ClusterManager.WorldManager.Protocol {
	partial class CM2WM {
		static public void GenerateId() {
			Engine.Foundation.Id<ClusterManager.WorldManager.Protocol.CM2WM>.Value = 0x13000000;
		}
	}
}
