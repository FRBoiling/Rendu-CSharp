using DataParserLib;
using ServerFrameWork;
using System.Collections.Generic;

namespace WorldServerLib
{
    public partial class Api
    {
        private WorldManagerServer _worldManagerServer;
        public WorldManagerServer WorldManagerServer { get => _worldManagerServer; }

        private void InitServers()
        {
            InitWorldManagerServer();
        }

        private void InitWorldManagerServer()
        {
            DataList serverConfig = XmlDataManager.Inst.GetDataList(ServerConfigConst.ServerConfig);
            List<Data> worldMangerServers = serverConfig.GetDatasByGroup(ServerGroup.WorldManagerServerGroup);

            foreach (var server in worldMangerServers)
            {
                ushort groupId = server.GetUInt16("GroupId");
                if (groupId == ApiTag.GroupId)
                {
                    string ip = server.GetString("Ip");
                    ushort port = server.GetUInt16("Port");
                    ushort subId = server.GetUInt16("SubId");

                    _worldManagerServer = new WorldManagerServer(this, ip, port);
                    _worldManagerServer.Tag.GroupId = groupId;
                    _worldManagerServer.Tag.SubId = subId;
                    _worldManagerServer.ReConnect();
                }
            }
        }

        private void UpdateServers()
        {
            _worldManagerServer.Process();
        }
    }
}
