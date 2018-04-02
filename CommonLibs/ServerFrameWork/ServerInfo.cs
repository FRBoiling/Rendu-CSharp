using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public class ServerInfo
    {
        /// <summary>
        /// 类型
        /// </summary>
        private ServerType _type;
        public ServerType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// 组号
        /// </summary>
        private ushort _groupId = 0;
        public ushort GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        private ushort _subId = 0;
        public ushort SubId
        {
            get { return _subId; }
            set { _subId = value; }
        }

        /// <summary>
        /// IP
        /// </summary>
        private string _ip = "127.0.0.1";

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        /// <summary>
        /// 端口
        /// </summary>
        private int _port = 0;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private IPEndPoint _iPEndPoint;
        public IPEndPoint IPEndPoint { get => _iPEndPoint; set => _iPEndPoint = value; }

        /// <summary>
        /// 名字
        /// </summary>
        /// <returns></returns>
        public string GetServerTagString()
        {
            string tag = string.Format("{0}_{1}_{2}", _type.ToString(), _groupId, _subId);
            return tag;
        }

        /// <summary>
        /// 完整编号
        /// </summary>
        /// <returns></returns>
        public string GetServerKey()
        {
            string key = string.Format("{0}_{1}",  _groupId, _subId);
            return key;
        }

        public void SetConnectInfo()
        {

        }
    }
}
