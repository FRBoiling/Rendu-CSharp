using System;

namespace TcpLib
{
    public class Packet:ICloneable
    {
        public PacketHead head = new PacketHead();
        public byte[] data;

        public Packet(PacketHead head)
        {
            this.head = (PacketHead)head.Clone();
            this.data = new byte[this.head.length];
        }

        public Packet(PacketHead head,byte[] packetData)
        {
            this.head = (PacketHead)head.Clone();
            this.data = new byte[this.head.length];
            Buffer.BlockCopy(packetData, 0, this.data, 0, this.head.length);
        }

        public object Clone()
        {
            return new Packet(head,data);
        }
    }
}
