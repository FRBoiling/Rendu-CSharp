using System;
namespace Message.World.ClusterManager.Protocol.W2CM {

	public partial class MSG_W2CM_HEARTBEAT {}
	public partial class MSG_W2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.World.ClusterManager.Protocol.W2CM.MSG_W2CM_HEARTBEAT>.Value = 0x41000001;
			Engine.Foundation.Id<Message.World.ClusterManager.Protocol.W2CM.MSG_W2CM_REGISTER>.Value = 0x41000002;
		}
	}

}
namespace World.ClusterManager.Protocol.W2CM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<World.ClusterManager.Protocol.W2CM.Provider>.Value = 0x41000000;
		}
	}
}
