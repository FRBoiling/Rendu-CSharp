using System;
namespace Message.World.WorldManager.Protocol.W2WM {

	public partial class MSG_W2WM_HEARTBEAT {}
	public partial class MSG_W2WM_REGISTER {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.World.WorldManager.Protocol.W2WM.MSG_W2WM_HEARTBEAT>.Value = 0x43000001;
			Engine.Foundation.Id<Message.World.WorldManager.Protocol.W2WM.MSG_W2WM_REGISTER>.Value = 0x43000002;
		}
	}

}
namespace World.WorldManager.Protocol.W2WM {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<World.WorldManager.Protocol.W2WM.Provider>.Value = 0x43000000;
		}
	}
}
