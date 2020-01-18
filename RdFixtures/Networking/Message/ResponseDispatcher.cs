using Rd.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rd.Networking
{
    public class ResponseDispatcher
    {
		private readonly Dictionary<int, Action<IResponse>> requestCallback = new Dictionary<int, Action<IResponse>>();

        public void Response(int opcode, IResponse response)
        {
			Action<IResponse> action;
			if (!this.requestCallback.TryGetValue(response.RpcId, out action))
			{
				throw new Exception($"not found rpc, response message: {StringHelper.MessageToStr(response)}");
			}
			this.requestCallback.Remove(response.RpcId);
        }
    }
}
