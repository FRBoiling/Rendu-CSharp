using System;
namespace Protocol.ClusterManager.CM2B {

	public partial class MSG_CM2B_HEARTBEAT {}
	public partial class MSG_CM2B_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.ClusterManager.CM2B.MSG_CM2B_HEARTBEAT>.Value = 0x1600001;
			Engine.Foundation.Id<Protocol.ClusterManager.CM2B.MSG_CM2B_RETRUN_REGISTER>.Value = 0x1600002;
		}
	}

}
