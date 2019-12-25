using System.Net.Sockets;

namespace Rd.Networking
{
    public delegate void TcpSocketReceive(AbstractTcpSocket tcpSocket, Socket socket, byte[] bytes);
}