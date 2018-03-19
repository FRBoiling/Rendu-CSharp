using System;
namespace Message.Client.Gate.Protocol.CG {

	public partial class MSG_C2G_HEARTBEAT {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_HEARTBEAT>.Value = 0xF2000001;
		}
	}

}
namespace Client.Gate.Protocol {
	partial class CG {
		static public void GenerateId() {
			Engine.Foundation.Id<Client.Gate.Protocol.CG>.Value = 0xF2000000;
		}
	}
}
