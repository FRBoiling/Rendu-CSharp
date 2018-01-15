using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public class ServerTag
    {
        private ServerType _type;
        public ServerType Type
        {
            get { return _type; }
            set { _type = value; }
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


        private int _port = 0;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string GetServerTagString()
        {
            string tag = string.Format("{0}_{1}_{2}", _type.ToString(), _groupId, _subId);
            return tag;
        }

        public string GetServerKey()
        {
            string key = string.Format("{0}_{1}",  _groupId, _subId);
            return key;
        }
    }
}
