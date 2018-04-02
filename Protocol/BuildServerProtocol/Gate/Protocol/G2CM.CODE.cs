using System;
namespace Message.Gate.ClusterManager.Protocol.G2CM {

	public partial class MSG_W2CM_Heartbeat {}
	public partial class MSG_W2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Gate.ClusterManager.Protocol.G2CM.MSG_W2CM_Heartbeat>.Value = 0x21000001;
			Engine.Foundation.Id<Message.Gate.ClusterManager.Protocol.G2CM.MSG_W2CM_Register>.Value = 0x21000002;
		}
	}

}
namespace Gate.ClusterManager.Protocol.G2CM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Gate.ClusterManager.Protocol.G2CM.Provider>.Value = 0x21000000;
		}
	}
}
