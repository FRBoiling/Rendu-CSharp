using System;
using System.Collections.Generic;
using System.IO;
using Engine.Foundation;
using ProtoBuf;

namespace TcpLib
{
    public class Packet1 : AbstractParsePacket
    {
        private Queue<KeyValuePair<UInt32, MemoryStream>> m_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();
        private Queue<KeyValuePair<UInt32, MemoryStream>> m_deal_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();

        public override int UnpackPacket(MemoryStream stream, int offset, byte[] buffer)
        {
            while ((stream.Length - offset) > sizeof(UInt16))
            {
                UInt16 size = BitConverter.ToUInt16(buffer, offset);
                if (size + PacketHead.Size > stream.Length - offset)
                {
                    break;
                }

                UInt32 msg_id = BitConverter.ToUInt32(buffer, offset + sizeof(UInt16));
                MemoryStream msg = new MemoryStream(buffer, offset + PacketHead.Size, size, true, true);
                lock (m_msgQueue)
                {
                    m_msgQueue.Enqueue(new KeyValuePair<uint, MemoryStream>(msg_id, msg));
                }
                offset += (size + PacketHead.Size);
            }

            return offset;
        }

        public override void PackPacket<T>(T msg, out MemoryStream head, out MemoryStream body, int uid = 0)
        {
            body = new MemoryStream();
            ProtoBuf.Serializer.Serialize(body, msg);

            head = new MemoryStream(sizeof(ushort) + sizeof(uint));
            ushort len = (ushort)body.Length;
            head.Write(BitConverter.GetBytes(len), 0, 2);
            head.Write(BitConverter.GetBytes(Id<T>.Value), 0, 4);
        }

        public override void OnProcessProtocal()
        {
            lock (m_msgQueue)
            {
                while (m_msgQueue.Count > 0)
                {
                    var msg = m_msgQueue.Dequeue();
                    m_deal_msgQueue.Enqueue(msg);
                }
            }
            while (m_deal_msgQueue.Count > 0)
            {
                var msg = m_deal_msgQueue.Dequeue();
                Process(msg.Key, msg.Value);
            }
        }

    }
}
