using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public class ServerTag
    {
        private string _serverType;
        public string ServerType
        {
            get { return _serverType; }
            set { _serverType = value; }
        }

        private ushort _groupId = 0;
        public ushort GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
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
            string tag = string.Format("{0}_{1}_{2}", _serverType, _groupId, _subId);
            return tag;
        }
    }
}
