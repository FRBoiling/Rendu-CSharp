using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public class ServerTag
    {
        private string _serverName;
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        private ushort _areaId = 0;
        public ushort AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        private ushort _serverId = 0;
        public ushort ServerId
        {
            get { return _serverId; }
            set { _serverId = value; }
        }

        private ushort _subId = 0;
        public ushort SubId
        {
            get { return _subId; }
            set { _subId = value; }
        }

        private string _ip = "127.0.0.1";

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public string GetServerTagString()
        {
            string tag = string.Format("{0}_{1}_{2}_{3}", _serverName, _areaId, _serverId, _subId);
            return tag;
        }
    }
}
