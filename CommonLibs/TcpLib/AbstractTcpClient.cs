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

        AbstractParsePacket _parser;

        public AbstractTcpClient(string ip,ushort port)
        {
            _ip = ip;
            _port = port;

            InitPacketPareser();
            BindResponser();
            InitTcp();
        }

        protected abstract void BindResponser();

        public void InitTcp()
        {
            _tcp.OnConnect = OnConnect;
            _tcp.OnRecv = OnRecv;
            _tcp.OnDisconnect = OnDisconnect;
        }

        public void InitPacketPareser()
        {
            _parser = InitPacketParser();
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
            ConnectedComplete(ret);

            if (ret == true)
            {
            }
            else
            {
                Connect();
            }
            return ret;
        }

        /// <summary>
        /// 已经连接，发包或者信息记录（具体内容需要根据实际具体需求实现）
        /// </summary>
        protected abstract void ConnectedComplete(bool ret);

        protected abstract AbstractParsePacket InitPacketParser();

        private void OnRecv(MemoryStream stream)
        {
            int offset = 0;
            byte[] buffer = stream.GetBuffer();
            offset = _parser.UnpackPacket(stream, offset, buffer);
            stream.Seek(offset, SeekOrigin.Begin);
        }

        private void ProcessProtocal()
        {
            _parser.OnProcessProtocal();
        }

        protected void AddProcesser(uint msgId, AbstractParsePacket.Processer processer)
        {
            _parser.AddProcesser(msgId, processer);
        }

        public bool Send<T>(T msg) where T : global::ProtoBuf.IExtensible
        {
            MemoryStream body, head;
            _parser.PackPacket(msg, out body, out head);
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

        public void Update()
        {
            ProcessProtocal();
        }

    }
}
