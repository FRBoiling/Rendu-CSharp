using System;
namespace Protocol.World.W2WM {

	public partial class MSG_W2WM_Heartbeat {}
	public partial class MSG_W2WM_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.World.W2WM.MSG_W2WM_Heartbeat>.Value = 0x4300001;
			Engine.Foundation.Id<Protocol.World.W2WM.MSG_W2WM_Register>.Value = 0x4300002;
		}
	}

}
