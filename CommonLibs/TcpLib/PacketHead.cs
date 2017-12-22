using System;

namespace TcpLib
{
    public class PacketHead:ICloneable
    {
        public UInt16 length;
        public UInt32 msg_id;

        static readonly public int Size = sizeof(UInt16) + sizeof(Int32);

        public PacketHead()
        {
            length = 0;
            msg_id = 0;
        }

        public   PacketHead(byte[] packetHead)
        {
            length = BitConverter.ToUInt16(packetHead, 0);
            msg_id = BitConverter.ToUInt16(packetHead, sizeof(UInt16));
        }

        public PacketHead(UInt16 length,UInt32 msg)
        {
            this.length = length;
            this.msg_id = msg;
        }

        public object Clone()
        {
            var clone = new PacketHead();
            clone.length = length;
            clone.msg_id = msg_id;
            return clone;
        }
    }
}
