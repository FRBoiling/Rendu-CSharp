using System;
namespace Message.Client.Gate.Protocol.CG {

	public partial class MSG_C2G_Heartbeat {}
	public partial class MSG_C2G_GetEncryptKey {}
	public partial class MSG_C2G_Login {}
	public partial class MSG_C2G_CreateRole {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_Heartbeat>.Value = 0xF2000001;
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_GetEncryptKey>.Value = 0xF2000010;
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_Login>.Value = 0xF2001000;
			Engine.Foundation.Id<Message.Client.Gate.Protocol.CG.MSG_C2G_CreateRole>.Value = 0xF2001001;
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
