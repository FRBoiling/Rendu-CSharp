using Entitas;
using Entitas.Attributes;
using Rd.Networking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Components
{
    [Context("Message")]
    public class MessageDispatcherComponent : IComponent
    {
        public IMessageDispatcher Dispatcher;
    }

}
