using System;
namespace Message.WorldManager.Gate.Protocol.WM2G {

	public partial class MSG_WM2G_Heartbeat {}
	public partial class MSG_WM2G_Register {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.WorldManager.Gate.Protocol.WM2G.MSG_WM2G_Heartbeat>.Value = 0x32000001;
			Engine.Foundation.Id<Message.WorldManager.Gate.Protocol.WM2G.MSG_WM2G_Register>.Value = 0x32000002;
		}
	}

}
namespace WorldManager.Gate.Protocol.WM2G {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<WorldManager.Gate.Protocol.WM2G.Provider>.Value = 0x32000000;
		}
	}
}
