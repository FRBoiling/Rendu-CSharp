using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public class ClientInfo
    {
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

        public string GetServerTagString()
        {
            return _iPEndPoint.ToString();
        }

    }
}
