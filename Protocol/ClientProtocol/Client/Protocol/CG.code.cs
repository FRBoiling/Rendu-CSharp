using System;
namespace Message.Client.Gate.Protocol.CG {

	public partial class MSG_C2G_HEARTBEAT {}
	public partial class MSG_C2G_GET_ENCRYPTKEY {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_HEARTBEAT>.Value = 0xF2000001;
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_GET_ENCRYPTKEY>.Value = 0xF2000010;
		}
	}

}
namespace Client.Gate.Protocol.CG {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Client.Gate.Protocol.CG.Provider>.Value = 0xF2000000;
		}
	}
}
