using System;
namespace Protocol.Gate.G2C {

	public partial class MSG_G2C_Heartbeat {}
	public partial class MSG_G2C_EncryptKey {}
	public partial class MSG_G2C_Login {}
	public partial class MSG_G2C_CreateRole {}
	public partial class Role_BaseInfo {}
	public partial class Role_Model {}
	public partial class Role_Info {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.Gate.G2C.MSG_G2C_Heartbeat>.Value = 0x2F00001;
			Engine.Foundation.Id<Protocol.Gate.G2C.MSG_G2C_EncryptKey>.Value = 0x2F00010;
			Engine.Foundation.Id<Protocol.Gate.G2C.MSG_G2C_Login>.Value = 0x2F00101;
			Engine.Foundation.Id<Protocol.Gate.G2C.MSG_G2C_CreateRole>.Value = 0x2F00102;
			Engine.Foundation.Id<Protocol.Gate.G2C.Role_BaseInfo>.Value = 0x2F00111;
			Engine.Foundation.Id<Protocol.Gate.G2C.Role_Model>.Value = 0x2F00112;
			Engine.Foundation.Id<Protocol.Gate.G2C.Role_Info>.Value = 0x2F00121;
		}
	}

}
