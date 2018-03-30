using System;
namespace Message.Gate.Client.Protocol.GC {

	public partial class MSG_G2C_Heartbeat {}
	public partial class MSG_G2C_EncryptKey {}
	public partial class MSG_G2C_Login {}
	public partial class MSG_G2C_CreateRole {}
	public partial class Role_BaseInfo {}
	public partial class Role_Model {}
	public partial class Role_Info {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.MSG_G2C_Heartbeat>.Value = 0x2F000001;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.MSG_G2C_EncryptKey>.Value = 0x2F000010;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.MSG_G2C_Login>.Value = 0x2F001000;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.MSG_G2C_CreateRole>.Value = 0x2F001001;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.Role_BaseInfo>.Value = 0x2F001050;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.Role_Model>.Value = 0x2F001051;
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.Role_Info>.Value = 0x2F001053;
		}
	}

}
namespace Gate.Client.Protocol.GC {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Gate.Client.Protocol.GC.Provider>.Value = 0x2F000000;
		}
	}
}
