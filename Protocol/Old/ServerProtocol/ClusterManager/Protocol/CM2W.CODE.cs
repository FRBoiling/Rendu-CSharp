using System;
namespace Protocol.ClusterManager.CM2W {

	public partial class MSG_CM2W_HEARTBEAT {}
	public partial class MSG_CM2W_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.ClusterManager.CM2W.MSG_CM2W_HEARTBEAT>.Value = 0x14000001;
			Engine.Foundation.Id<Protocol.ClusterManager.CM2W.MSG_CM2W_RETRUN_REGISTER>.Value = 0x14000002;
		}
	}

}
