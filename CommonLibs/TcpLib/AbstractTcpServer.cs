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

        AbstractParsePacket _parser;

        public AbstractTcpServer(ushort port)
        {
            _listenPort = port;
            InitPacketPareser();
            BindResponser();
            InitTcp();
        }

        protected abstract void BindResponser();

        private void InitTcp()
        {
            _tcp.OnAccept = OnAccpet;
            _tcp.OnRecv = OnRecv;
            _tcp.OnDisconnect = OnDisconnect;
        }

        private void InitPacketPareser()
        {
            _parser = InitPacketParser();
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

        protected abstract AbstractParsePacket InitPacketParser();

        private void OnRecv(MemoryStream stream)
        {
           int offset = _parser.UnpackPacket(stream);
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
            StartListen();
            return true;
        }

        public void Update()
        {
            ProcessProtocal();
        }

    }
}
