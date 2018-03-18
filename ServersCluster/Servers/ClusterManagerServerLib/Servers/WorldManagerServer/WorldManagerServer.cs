using Engine.Foundation;
using LogLib;
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
        ServerInfo _tag = new ServerInfo();

        public ServerInfo Tag
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

            Log.Info("{0} server connected", Tag.Type);
            _manager.AddAccpetServer(this);
        }

        protected override void DisconnectComplete()
        {
            Log.Info("{0} server disconnected", Tag.GetServerTagString());
            _manager.RemoveServer(this);
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
                Log.Info("{0} regist succese", Tag.GetServerTagString());
            }
            else
            {
                Log.Warn("{0} regist fail", Tag.GetServerTagString());
            }
        }

        protected override void ProcessLogic()
        {
            throw new NotImplementedException();
        }
    }
}
