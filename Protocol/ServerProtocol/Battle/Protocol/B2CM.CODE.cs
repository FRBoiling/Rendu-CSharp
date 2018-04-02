using System;
namespace Message.Battle.ClusterManager.Protocol.B2CM {

	public partial class MSG_B2CM_Heartbeat {}
	public partial class MSG_B2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Battle.ClusterManager.Protocol.B2CM.MSG_B2CM_Heartbeat>.Value = 0x61000001;
			Engine.Foundation.Id<Message.Battle.ClusterManager.Protocol.B2CM.MSG_B2CM_Register>.Value = 0x61000002;
		}
	}

}
namespace Battle.ClusterManager.Protocol.B2CM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Battle.ClusterManager.Protocol.B2CM.Provider>.Value = 0x61000000;
		}
	}
}
