using System;
namespace Protocol.Battle.B2CM {

	public partial class MSG_B2CM_Heartbeat {}
	public partial class MSG_B2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.Battle.B2CM.MSG_B2CM_Heartbeat>.Value = 0x6100001;
			Engine.Foundation.Id<Protocol.Battle.B2CM.MSG_B2CM_Register>.Value = 0x6100002;
		}
	}

}
