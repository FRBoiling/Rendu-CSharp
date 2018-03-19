using ProtoBuf;

namespace TcpLib
{
    public interface ITcpServer
    {
        void Process();
        bool Send<T>(T msg) where T : IExtensible;

        ushort ListenPort { get; }
        void StartListen(bool needListen = false);
        void StartListen(ushort port);
        void StartListen(ushort port, bool needListenHeatBeat = false);

        void Exit();
    }
}