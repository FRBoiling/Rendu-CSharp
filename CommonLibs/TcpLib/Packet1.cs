using System;
using System.Collections.Generic;
using System.IO;
using Engine.Foundation;
using Protocol.Client.C2G;

namespace TcpLib
{
    public class Packet1 : AbstractParsePacket
    {
        private Queue<KeyValuePair<UInt32, MemoryStream>> m_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();
        private Queue<KeyValuePair<UInt32, MemoryStream>> m_deal_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();

        public override int UnpackPacket(MemoryStream stream)
        {
            byte[] buffer = stream.GetBuffer();
            int offset = 0;
            int pos = 0;
            while (stream.Length > sizeof(UInt16))
            {
                UInt16 size = BitConverter.ToUInt16(buffer, offset);
                offset += sizeof(UInt16);
                if (size > stream.Length - offset)
                {
                    break;
                }

                UInt32 msg_id = BitConverter.ToUInt32(buffer, offset);
                offset += sizeof(UInt32);
                //byte[] content = new byte[size];
                //Array.Copy(buffer, offset , content, 0, size);
                MemoryStream msg = new MemoryStream(buffer, offset, size, true, true);
                lock (m_msgQueue)
                {
                    m_msgQueue.Enqueue(new KeyValuePair<uint, MemoryStream>(msg_id, msg));
                }
                offset += size ;
                pos = offset;
            }

            return pos;
        }

        public override int CryptoUnpackPacket(MemoryStream stream)
        {
            byte[] buffer = stream.GetBuffer();
            int offset = 0;
            int pos = 0;
            while (stream.Length > sizeof(UInt16))
            {
                UInt16 size = BitConverter.ToUInt16(buffer, offset);
                offset += sizeof(UInt16);
                if (size > stream.Length - offset)
                {
                    break;
                }
                UInt16 trueLen = BitConverter.ToUInt16(buffer, offset);
                offset += sizeof(UInt16);
                UInt32 msg_id = BitConverter.ToUInt32(buffer, offset);
                offset += sizeof(UInt32);
                //byte[] content = new byte[size];
                //Array.Copy(buffer, offset , content, 0, size);
                MemoryStream msg = new MemoryStream(buffer, offset, size, true, true);
                MemoryStream trueStream = null;
                if (msg_id!=Id<MSG_C2G_GetEncryptKey>.Value)
                {
                    if (size>0)
                    {
                        if (BlowFishHandler == null)
                        {
                            return -1;
                        }
                        trueStream = BlowFishHandler.Decrypt_CBC(msg, 0, size);
                        trueStream.SetLength(trueLen);
                    }
                    else
                    {
                        trueStream = msg;
                    }
                }
                else
                {
                    trueStream = msg;
                }
                lock (m_msgQueue)
                {
                    m_msgQueue.Enqueue(new KeyValuePair<uint, MemoryStream>(msg_id, msg));
                }
                offset += size;
                pos = offset;
            }

            return pos;
        }

        public override void Process()
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

        public override void PackPacket<T>(T msg, out MemoryStream head, out MemoryStream body)
        {
            body = new MemoryStream();
            ProtoBuf.Serializer.Serialize(body, msg);

            head = new MemoryStream(sizeof(short) + sizeof(int));
            short len = (short)body.Length;
            head.Write(BitConverter.GetBytes(len), 0, sizeof(short));
            head.Write(BitConverter.GetBytes(Id<T>.Value), 0, sizeof(int));
        }

    

        public override void PackPacket<T>(T msg, int uid, out MemoryStream head, out MemoryStream body)
        {
            throw new NotImplementedException();
        }


    }
}
