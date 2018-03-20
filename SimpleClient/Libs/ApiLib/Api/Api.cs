using ClientLib;
using System;

namespace ApiLib
{
    public class Api : IApi
    {
        GateServer _api;

        public Api()
        {
            _api = new GateServer();
        }


        public void Exit()
        {
            _api.Exit();
        }

        public void Init(string ip, ushort port)
        {
            _api.Init(ip, port);
        }

        public void Process()
        {
            _api.Process();
        }

        public void ReConnect()
        {
            _api.ReConnect();
        }

        public object RouteGet(string key)
        {
            return _api.RouteGet(key);
        }

        public object RouteInit(string key)
        {
            return _api.RouteInit(key);
        }

        public void RouteSend(string key, object msg)
        {
            _api.RouteSend(key,msg); ;
        }

    }
}
