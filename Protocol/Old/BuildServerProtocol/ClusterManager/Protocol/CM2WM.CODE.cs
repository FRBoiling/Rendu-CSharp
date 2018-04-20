using System;
namespace Protocol.ClusterManager.CM2WM {

	public partial class MSG_CM2WM_HEARTBEAT {}
	public partial class MSG_CM2WM_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.ClusterManager.CM2WM.MSG_CM2WM_HEARTBEAT>.Value = 0x1300001;
			Engine.Foundation.Id<Protocol.ClusterManager.CM2WM.MSG_CM2WM_RETRUN_REGISTER>.Value = 0x1300002;
		}
	}

}
