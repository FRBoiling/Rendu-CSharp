namespace ApiLib
{
    public interface IApi
    {
        void Exit();
        void Init(string v1, ushort v2);
        void Process();
        void ReConnect();
        object RouteGet(string key);
        object RouteInit(string key);
        void RouteSend(string key, object msg);
    }
}