using Engine.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TcpLib.TcpSrc;


namespace TcpLib
{
    public abstract class AbstractTcpClient
    {
        private Tcp _tcp = new Tcp();

        private string _ip;
        public string Ip
        {
            get { return _ip; }
        }

        private ushort _port;
        public ushort Port
        {
            get { return _port; }
        }

        public AbstractTcpClient(string ip,ushort port)
        {
            _ip = ip;
            _port = port;
        }

        public void InitTcp()
        {
            _tcp.OnConnect = OnConnect;
            _tcp.OnRecv = OnRecv;
            _tcp.OnDisconnect = OnDisconnect;
        }

        public void Connect()
        {
            Connect(Ip, Port);
        }

        public void Connect(string ip,ushort port)
        {
            if (_tcp == null)
            {
                _tcp = new Tcp();
                InitTcp();
            }

            if (!_tcp.Connect(ip, port))
            {
                Connect(ip,port);
            }
            else
            {
                //连接
                Thread.Sleep(1000);
            }
        }

        private bool OnConnect(bool ret)
        {
            if (ret == true)
            {
                ConnectedComplete(ret);
            }
            else
            {
                ConnectedComplete(ret);
                Connect();
            }
            return ret;
        }

        /// <summary>
        /// 已经连接，发包或者信息记录（具体内容需要根据实际具体需求实现）
        /// </summary>
        protected abstract void ConnectedComplete(bool ret);

        protected Queue<KeyValuePair<UInt32, MemoryStream>> m_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();
        protected Queue<KeyValuePair<UInt32, MemoryStream>> m_deal_msgQueue = new Queue<KeyValuePair<uint, MemoryStream>>();

        private void OnRecv(MemoryStream stream)
        {
            int offset = 0;
            byte[] buffer = stream.GetBuffer();
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
            stream.Seek(offset, SeekOrigin.Begin);
        }

        public void OnProcessProtocal()
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
                OnResponse(msg.Key, msg.Value);
            }
        }

        private void OnResponse(uint id, MemoryStream stream)
        {
            try
            {
                Response(id, stream);
            }
            catch (Exception e)
            {
                Console.WriteLine("OnResponse:({0})[Error]{1}", id, e.ToString());
            }
        }

        protected abstract void Response(uint id, MemoryStream stream);

        public bool Send<T>(T msg) where T : global::ProtoBuf.IExtensible
        {
            MemoryStream body = new MemoryStream();
            ProtoBuf.Serializer.Serialize(body, msg);

            MemoryStream head = new MemoryStream(sizeof(ushort) + sizeof(uint));
            ushort len = (ushort)body.Length;
            head.Write(BitConverter.GetBytes(len), 0, 2);
            head.Write(BitConverter.GetBytes(Id<T>.Value), 0, 4);
            return Send(head, body);
        }

        private bool Send(MemoryStream head, MemoryStream body)
        {
            if (_tcp == null)
            {
                return false;
            }
            return _tcp.Send(head, body);
        }

        protected abstract void DisconnectComplete();
        private bool OnDisconnect()
        {
            DisconnectComplete();
            Connect();
            return true;
        }

    }
}
