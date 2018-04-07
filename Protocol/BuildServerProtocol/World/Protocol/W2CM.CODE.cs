using System;
namespace Protocol.World.W2CM {

	public partial class MSG_W2CM_Heartbeat {}
	public partial class MSG_W2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.World.W2CM.MSG_W2CM_Heartbeat>.Value = 0x4100001;
			Engine.Foundation.Id<Protocol.World.W2CM.MSG_W2CM_Register>.Value = 0x4100002;
		}
	}

}
