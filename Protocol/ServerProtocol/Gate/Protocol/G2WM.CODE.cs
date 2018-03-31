using System;
namespace Message.Gate.WorldManager.Protocol.G2WM {

	public partial class MSG_G2WM_Heartbeat {}
	public partial class MSG_G2WM_CreateRoleId {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Gate.WorldManager.Protocol.G2WM.MSG_G2WM_Heartbeat>.Value = 0x23000001;
			Engine.Foundation.Id<Message.Gate.WorldManager.Protocol.G2WM.MSG_G2WM_CreateRoleId>.Value = 0x23000101;
		}
	}

}
namespace Gate.WorldManager.Protocol.G2WM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Gate.WorldManager.Protocol.G2WM.Provider>.Value = 0x23000000;
		}
	}
}
