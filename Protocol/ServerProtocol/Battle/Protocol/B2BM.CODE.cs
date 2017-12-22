using System;
namespace Message.Server.Battle.Protocol.B2BM {

	public partial class MSG_B2BM_HEARTBEAT {}
	public partial class MSG_B2BM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Server.Battle.Protocol.B2BM.MSG_B2BM_HEARTBEAT>.Value = 0x03020001;
			Engine.Foundation.Id<Message.Server.Battle.Protocol.B2BM.MSG_B2BM_REGISTER>.Value = 0x03020002;
		}
	}

}
namespace Server.Battle.Protocol {
	partial class B2BM {
		static public void GenerateId() {
			Engine.Foundation.Id<Server.Battle.Protocol.B2BM>.Value = 0x03020000;
		}
	}
}
