using System;
namespace Message.WorldManager.ClusterManager.Protocol.WM2CM {

	public partial class MSG_WM2CM_HEARTBEAT {}
	public partial class MSG_WM2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.WorldManager.ClusterManager.Protocol.WM2CM.MSG_WM2CM_HEARTBEAT>.Value = 0x31000001;
			Engine.Foundation.Id<Message.WorldManager.ClusterManager.Protocol.WM2CM.MSG_WM2CM_REGISTER>.Value = 0x31000002;
		}
	}

}
namespace WorldManager.ClusterManager.Protocol.WM2CM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<WorldManager.ClusterManager.Protocol.WM2CM.Provider>.Value = 0x31000000;
		}
	}
}
