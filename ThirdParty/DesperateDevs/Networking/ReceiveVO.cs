using System.Net.Sockets;

namespace DesperateDevs.Networking
{
    public class ReceiveVO
    {
        public readonly Socket socket;
        public readonly byte[] bytes;

        public ReceiveVO(Socket socket, byte[] bytes)
        {
            this.socket = socket;
            this.bytes = bytes;
        }
    }
}