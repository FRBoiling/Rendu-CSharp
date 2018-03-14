﻿using Engine.Foundation;
using Message.BattleManager.ClusterManager.Protocol.BM2CM;
using Message.WorldManager.ClusterManager.Protocol.WM2CM;
using ServerFrameWork;
using System;
using System.Collections.Generic;
using System.IO;
using TcpLib;

namespace ClusterManagerServerLib.Server
{
    public class WorldManagerServer : AbstractTcpServer
    {
        ServerTag _tag = new ServerTag();

        public ServerTag Tag
        {
            get { return _tag; }
        }

        private WorldManagerServerMgr _manager;

        public WorldManagerServer(WorldManagerServerMgr manager, ushort port)
            : base(port)
        {
            _manager = manager;
            _tag.Type = ServerType.WorldManager;
        }

        public string GetKey()
        {
            return Tag.GetServerKey();
        }

        protected override void AccpetComplete()
        {

            Console.WriteLine("{0} server connected", Tag.Type);
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Console.WriteLine("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
        }

        protected override AbstractParsePacket InitPacketParser()
        {
            return new Packet1();
        }

        protected override void BindResponser()
        {
            AddProcesser(Id<MSG_WM2CM_REGISTER>.Value, OnResponse_Regist);
        }

        private void OnResponse_Regist(MemoryStream stream, int uid)
        {
            MSG_WM2CM_REGISTER msg = ProtoBuf.Serializer.Deserialize<MSG_WM2CM_REGISTER>(stream);
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