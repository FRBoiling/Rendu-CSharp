using System;
namespace Protocol.Client.C2G {

	public partial class MSG_C2G_Heartbeat {}
	public partial class MSG_C2G_GetEncryptKey {}
	public partial class MSG_C2G_Login {}
	public partial class MSG_C2G_CreateRole {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.Client.C2G.MSG_C2G_Heartbeat>.Value = 0xF200001;
			Engine.Foundation.Id<Protocol.Client.C2G.MSG_C2G_GetEncryptKey>.Value = 0xF200010;
			Engine.Foundation.Id<Protocol.Client.C2G.MSG_C2G_Login>.Value = 0xF200101;
			Engine.Foundation.Id<Protocol.Client.C2G.MSG_C2G_CreateRole>.Value = 0xF200102;
		}
	}

}
