using Rd.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rd.Networking
{
    public class StringPacker : IMessagePacker
    {
        private int packetSizeLength;

        public StringPacker(int packetSizeLength)
        {
            this.packetSizeLength = packetSizeLength;
        }

        public byte[] SerializeTo(object obj)
        {
			return StringHelper.ToByteArray((string)obj);
        }

        public void SerializeTo(object obj, MemoryStream stream)
        {
            StringHelper.ToStream((string)obj, stream);
        }


        public object DeserializeFrom(Type type, byte[] bytes, int index, int count)
        {
			return StringHelper.FromBytes(type, bytes, index, count);
        }

        public object DeserializeFrom(object instance, byte[] bytes, int index, int count)
        {
			return StringHelper.FromBytes(instance, bytes, index, count);
        }

        public object DeserializeFrom(Type type, MemoryStream stream)
        {
			return StringHelper.FromStream(type, stream);
        }

        public object DeserializeFrom(object instance, MemoryStream stream)
        {
			return StringHelper.FromStream(instance, stream);
        }

        public int GetPacketSize()
        {
            return packetSizeLength;
        }
    }
}
