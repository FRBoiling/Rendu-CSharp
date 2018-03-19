using System;
namespace Message.Gate.Client.Protocol.GC {

	public class Api {
		static public void GenerateId() {
		}
	}

}
namespace Gate.Client.Protocol {
	partial class GC {
		static public void GenerateId() {
			Engine.Foundation.Id<Gate.Client.Protocol.GC>.Value = 0x2F000000;
		}
	}
}
