using System;
namespace Protocol.ClusterManager.CM2BM {

	public partial class MSG_CM2BM_HEARTBEAT {}
	public partial class MSG_CM2BM_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.ClusterManager.CM2BM.MSG_CM2BM_HEARTBEAT>.Value = 0x1500001;
			Engine.Foundation.Id<Protocol.ClusterManager.CM2BM.MSG_CM2BM_RETRUN_REGISTER>.Value = 0x1500002;
		}
	}

}
