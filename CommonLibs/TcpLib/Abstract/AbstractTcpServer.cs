using CryptoLib;
using ServerFrameWork;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TcpLib.TcpSrc;

namespace TcpLib
{
    public abstract class AbstractTcpServer : ITcpServer
    {
        private ITcp _tcp = new Tcp();
        public ITcp Tcp { get => _tcp; }

        string _key = "0_0";
        public string Key { get => _key; set => _key = value; }

        string _name = "deafultServer";
        public string Name { get => _name; set => _name = value; }


        private ushort _listenPort;
        public ushort ListenPort
        {
            get { return _listenPort; }
        }


        IPacketOperate _packetOperate;
        IProtocolProcess _protocolProcess;

        public AbstractTcpServer(ushort port)
        {
            _listenPort = port;
            InitParser();
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

        protected void MarkConnectTag(ServerInfo info)
        {
            Socket workerSocket = Tcp.GetWorkSoket();
            info.IPEndPoint = (IPEndPoint)workerSocket.RemoteEndPoint;
            IPAddress remote_ip = info.IPEndPoint.Address;//获取远程连接IP 
            info.Ip = remote_ip.ToString();
            info.Port = info.IPEndPoint.Port;
        }

        protected void MarkConnectTag(ClientInfo info)
        {
            Socket workerSocket = Tcp.GetWorkSoket();
            info.IPEndPoint = (IPEndPoint)workerSocket.RemoteEndPoint;
            IPAddress remote_ip = info.IPEndPoint.Address;//获取远程连接IP 
            info.Ip = remote_ip.ToString();
            info.Port = info.IPEndPoint.Port;
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


        private void OnRecv(MemoryStream stream)
        {
            int offset = 0;
            if (((AbstractParsePacket)_packetOperate).BlowFishHandler == null)
            {
                offset = _packetOperate.UnpackPacket(stream);
            }
            else
            {
                offset = _packetOperate.CryptoUnpackPacket(stream);
            }
            stream.Seek(offset, SeekOrigin.Begin);
        }

        private void ProcessProtocal()
        {
            _protocolProcess.Process();
        }
        protected abstract void ProcessLogic();

        protected void AddProcesser(uint msgId, ProtocolProcessHandler.Processer processer)
        {
            _protocolProcess.AddProcesser(msgId, processer);
        }


        public bool Send<T>(T msg) where T : global::ProtoBuf.IExtensible
        {
            MemoryStream body, head;
            _packetOperate.PackPacket(msg, out head, out body);
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

        public void Process()
        {
            ProcessProtocal();
            ProcessLogic();
        }

        public void InitParser()
        {
            Packet1 packet = new Packet1();
            _packetOperate = packet;
            _protocolProcess = packet;
        }

        public void SetParser(AbstractParsePacket packet)
        {
            _packetOperate = packet;
            _protocolProcess = packet;
        }

        public void SetBlowFish(BlowFish blowFish)
        {
            ((AbstractParsePacket)_packetOperate).BlowFishHandler = blowFish;
        }

        public void Exit()
        {
            _tcp.Disconnect();
        }
    }
}
