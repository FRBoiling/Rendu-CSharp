using Entitas.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rd.Networking
{
    public interface IMessageDispatcher
    {
		void Dispatch(Entity session, ushort opcode, object message);
    }
}
