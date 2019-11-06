using System.Net.Sockets;

namespace DesperateDevs.Networking
{
    public delegate void TcpSocketReceive(AbstractTcpSocket tcpSocket, Socket socket, byte[] bytes);
}