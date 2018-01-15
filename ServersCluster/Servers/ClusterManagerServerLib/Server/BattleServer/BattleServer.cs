using Engine.Foundation;
using Message.Battle.ClusterManager.Protocol.B2CM;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;
using TcpLib.TcpSrc;

namespace ClusterManagerServerLib.Server
{
    public class BattleServer : AbstractTcpServer
    {
        ServerTag _tag = new ServerTag();

        public ServerTag Tag
        {
            get { return _tag; }
        }

        private BattleServerMgr _manager;

        public BattleServer(BattleServerMgr manager , ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.Type = ServerType.Battle;
            BindResponser();
            InitTcp();
        }


        protected override void AccpetComplete()
        {

            Console.WriteLine("{0} server connected", _tag.Type);
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        public override void Update() 
        {
            OnProcessProtocal();
        }

        public delegate void Responseer(MemoryStream stream);
        private Dictionary<uint, Responseer> _responsers = new Dictionary<uint, Responseer>();

        private void AddResponser(uint id, Responseer responser)
        {
            _responsers.Add(id, responser);
        }

        private void OnProcessProtocal()
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

        private void Response(uint id, MemoryStream stream)
        {
            Responseer responser = null;
            if (_responsers.TryGetValue(id, out responser))
            {
                responser(stream);
            }
            else
            {
                Console.WriteLine("got unsupported packet {0} from {1}",
                    id, Tag.GetServerTagString());
            }
        }

        private void BindResponser()
        {
            AddResponser(Id<MSG_B2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream)
        {
            MSG_B2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_B2CM_REGISTER>(stream);
            _tag.GroupId = (ushort)msg.GroupId;
            _tag.SubId = (ushort)msg.SubId;
            Key = _tag.GetServerKey();
            Name = _tag.Type.ToString();
            if (_manager.AddServer(this))
            {
                Console.WriteLine("{0} regist succese", Tag.GetServerTagString());
            }
        }

    }
}
