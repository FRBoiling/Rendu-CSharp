using System;
namespace Message.WorldManager.World.Protocol.WM2W {

	public partial class MSG_WM2W_HEARTBEAT {}
	public partial class MSG_WM2W_RETRUN_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.WorldManager.World.Protocol.WM2W.MSG_WM2W_HEARTBEAT>.Value = 0x34000001;
			Engine.Foundation.Id<Message.WorldManager.World.Protocol.WM2W.MSG_WM2W_RETRUN_REGISTER>.Value = 0x34000002;
		}
	}

}
namespace WorldManager.World.Protocol.WM2W {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<WorldManager.World.Protocol.WM2W.Provider>.Value = 0x34000000;
		}
	}
}
