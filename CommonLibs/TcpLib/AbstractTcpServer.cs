using Engine.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpLib.TcpSrc;

namespace TcpLib
{
    public abstract class AbstractTcpServer
    {
        private Tcp _tcp = new Tcp();
        string _key = "0_0";
        public string Key { get => _key; set => _key = value; }

        string _name = "deafultServer";
        public string Name { get => _name; set => _name = value; }


        private ushort _listenPort;
        public ushort ListenPort
        {
            get { return _listenPort; }
        }


        public AbstractTcpServer(ushort port)
        {
            _listenPort = port;
        }
        public void InitTcp()
        {
            _tcp.OnAccept = OnAccpet;
            _tcp.OnRecv = OnRecv;
            _tcp.OnDisconnect = OnDisconnect;
        }

        public void StartListen(ushort port, bool needListenHeatBeat = false)
        {
            _tcp.NeedListenHeartBeat = needListenHeatBeat;
            _tcp.Accept(ListenPort);
        }
        public void StartListen(ushort port)
        {
            _tcp.Accept(ListenPort);
        }

        public void StartListen(bool needListen = false)
        {
            StartListen(ListenPort, needListen);
        }

        public void StartListen()
        {
            StartListen(ListenPort);
        }

        private bool OnAccpet(bool ret)
        {
            if (ret)
            {
                AccpetComplete();
            }
            else
            {
                Console.WriteLine("accpet failed");
            }
            return ret;
        }

        /// <summary>
        /// 已经保持，发包或者信息记录（具体内容需要根据实际具体需求实现）
        /// </summary>
        protected abstract void AccpetComplete();

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
            StartListen();
            return true;
        }

        public abstract void Update();

    }
}
