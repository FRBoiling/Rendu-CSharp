using System.Net.Sockets;

namespace Rd.Networking
{
    public class ReceiveVO
    {
        public readonly byte[] bytes;
        public readonly Socket socket;

        public ReceiveVO(Socket socket, byte[] bytes)
        {
            this.socket = socket;
            this.bytes = bytes;
        }
    }
}