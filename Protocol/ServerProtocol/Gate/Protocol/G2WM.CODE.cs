using System;
namespace Protocol.Gate.G2WM {

	public partial class MSG_G2WM_Heartbeat {}
	public partial class MSG_G2WM_CreateRoleId {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.Gate.G2WM.MSG_G2WM_Heartbeat>.Value = 0x2300001;
			Engine.Foundation.Id<Protocol.Gate.G2WM.MSG_G2WM_CreateRoleId>.Value = 0x2300101;
		}
	}

}
