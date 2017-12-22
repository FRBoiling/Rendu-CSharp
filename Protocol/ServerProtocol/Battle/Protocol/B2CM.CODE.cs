using System;
namespace Message.Server.Battle.Protocol.B2CM {

	public partial class MSG_B2CM_HEARTBEAT {}
	public partial class MSG_B2CM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Server.Battle.Protocol.B2CM.MSG_B2CM_HEARTBEAT>.Value = 0x03010001;
			Engine.Foundation.Id<Message.Server.Battle.Protocol.B2CM.MSG_B2CM_REGISTER>.Value = 0x03010002;
		}
	}

}
namespace Server.Battle.Protocol {
	partial class B2CM {
		static public void GenerateId() {
			Engine.Foundation.Id<Server.Battle.Protocol.B2CM>.Value = 0x03010000;
		}
	}
}
