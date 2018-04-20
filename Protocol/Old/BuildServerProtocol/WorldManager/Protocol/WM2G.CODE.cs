using System;
namespace Protocol.WorldManager.WM2G {

	public partial class MSG_WM2G_Heartbeat {}
	public partial class MSG_WM2G_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Protocol.WorldManager.WM2G.MSG_WM2G_Heartbeat>.Value = 0x3200001;
			Engine.Foundation.Id<Protocol.WorldManager.WM2G.MSG_WM2G_Register>.Value = 0x3200002;
		}
	}

}
