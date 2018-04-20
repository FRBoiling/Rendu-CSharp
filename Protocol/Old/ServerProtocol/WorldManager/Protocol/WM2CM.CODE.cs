using System;
namespace Protocol.WorldManager.WM2CM {

	public partial class MSG_WM2CM_Heartbeat {}
	public partial class MSG_WM2CM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.WorldManager.WM2CM.MSG_WM2CM_Heartbeat>.Value = 0x3100001;
			Engine.Foundation.Id<Protocol.WorldManager.WM2CM.MSG_WM2CM_Register>.Value = 0x3100002;
		}
	}

}
