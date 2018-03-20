using System;
namespace Message.Gate.Client.Protocol.GC {

	public partial class MSG_G2C_ENCRYPTKEY {}
	public class Api {
		static public void GenerateId() {
			Engine.Foundation.Id<Message.Gate.Client.Protocol.GC.MSG_G2C_ENCRYPTKEY>.Value = 0x2F000010;
		}
	}

}
namespace Gate.Client.Protocol.GC {
	partial class Provider {
		static public void GenerateId() {
			Engine.Foundation.Id<Gate.Client.Protocol.GC.Provider>.Value = 0x2F000000;
		}
	}
}
