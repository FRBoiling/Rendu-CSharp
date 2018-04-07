using System;
namespace Protocol.Gate.G2CM {

	public partial class MSG_G2CM_Heartbeat {}
	public partial class MSG_G2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.Gate.G2CM.MSG_G2CM_Heartbeat>.Value = 0x2100001;
			Engine.Foundation.Id<Protocol.Gate.G2CM.MSG_G2CM_Register>.Value = 0x2100002;
		}
	}

}
