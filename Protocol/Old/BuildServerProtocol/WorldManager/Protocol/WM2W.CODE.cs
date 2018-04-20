using System;
namespace Protocol.WorldManager.WM2W {

	public partial class MSG_WM2W_HEARTBEAT {}
	public partial class MSG_WM2W_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.WorldManager.WM2W.MSG_WM2W_HEARTBEAT>.Value = 0x3400001;
			Engine.Foundation.Id<Protocol.WorldManager.WM2W.MSG_WM2W_RETRUN_REGISTER>.Value = 0x3400002;
		}
	}

}
