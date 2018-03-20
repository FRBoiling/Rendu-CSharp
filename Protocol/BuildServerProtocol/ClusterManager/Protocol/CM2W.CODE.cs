using System;
namespace Message.ClusterManager.World.Protocol.CM2W {

	public partial class MSG_CM2W_HEARTBEAT {}
	public partial class MSG_CM2W_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.ClusterManager.World.Protocol.CM2W.MSG_CM2W_HEARTBEAT>.Value = 0x14000001;
			Engine.Foundation.Id<Message.ClusterManager.World.Protocol.CM2W.MSG_CM2W_RETRUN_REGISTER>.Value = 0x14000002;
		}
	}

}
namespace ClusterManager.World.Protocol.CM2W {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<ClusterManager.World.Protocol.CM2W.Provider>.Value = 0x14000000;
		}
	}
}
