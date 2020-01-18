using Rd.Networking.IOCP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rd.Networking
{
    public class MessagePackerFactory
    {
        public static IMessagePacker Create(SessionType sessionType)
        {
            switch (sessionType)
            {
                case SessionType.Server:
                    return new ProtobufPacker(Packet.PacketSizeLength2);
                case SessionType.Client:
                    return new StringPacker(Packet.PacketSizeLength4);
                default:
                    return new ProtobufPacker(Packet.PacketSizeLength2);
            }
        }
    }
}
