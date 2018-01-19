using Engine.Foundation;
using System;
using System.Collections.Generic;
using System.IO;

namespace TcpLib
{

    public abstract class AbstractParsePacket
    {
        public delegate void Processer(MemoryStream stream, int uid = 0);
        private Dictionary<uint, Processer> _processers = new Dictionary<uint, Processer>();

        public abstract int UnpackPacket(MemoryStream stream, int offset, byte[] buffer);
        public abstract void PackPacket<T>(T msg, out MemoryStream head, out MemoryStream body, int uid = 0) where T : ProtoBuf.IExtensible;
        public abstract void OnProcessProtocal();
        public void AddProcesser(uint id, Processer processer)
        {
            _processers.Add(id, processer);
        }
        protected bool Process(uint id,MemoryStream stream,int uid = 0)
        {
            Processer processer;
            if (_processers.TryGetValue(id,out processer))
            {
                processer(stream, uid);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
