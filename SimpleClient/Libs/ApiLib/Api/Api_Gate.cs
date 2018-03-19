using AssemblyLib;
using ClientLib;
using System.Collections.Generic;
using System.Reflection;

namespace ApiLib
{
    public partial class Api
    {
        object objInfo;
        GateServer server;
 
        public bool InitSocket()
        {
            //return InitSocket_Assembly();
            server = new GateServer();
            return true;
        }



        private void Connect2GateServer()
        {
            //ushort groupId = server.GetUInt16("GroupId");
            //string ip = server.GetString("Ip");
            //ushort port = server.GetUInt16("Port");
            //ushort subId = server.GetUInt16("SubId");
            //ushort groupId = 1;
            //ushort subId = 1;
            string ip = "127.0.0.1";
            ushort port = 8201;

            InitConnectInfo(ip,port);
            ReConnect();
        }

        void InitConnectInfo(string ip, ushort port)
        {
            //InitConnectInfo_Assembly(ip, port);
            server.InitConnectInfo(ip, port);
        }

        void InitConnectInfo_Assembly(string ip, ushort port)
        {
            if (objInfo == null)
            {
                return;
            }
            //_gateServer = new GateServer(this, ip, port);
            //_gateServer.Tag.GroupId = groupId;
            //_gateServer.Tag.SubId = subId;
            object[] parameters = new object[] { this,ip,port };
            MethodInfo meth = objInfo.GetType().GetMethod("InitConnectInfo");
            meth.Invoke(objInfo, parameters);
        }

        public void ExitSocket()
        {
            //ExitSocket_Assembly();
            server.Exit();
        }

        void ReConnect()
        {
            //Connect_Assembly();
            server.ReConnect();
        }


        void ProcessLogic()
        {
            //Process_Assembly();
            server.Process();
        }

        public object RouteInit(string key)
        {
            //return RouteInit_Assembly(key);
            return server.RouteInit(key);
        }

        public object RouteGet(string key)
        {
            //return RouteGet_Assembly(key);
            return server.RouteGet(key);
        }

        public void RouteSend(string key, object msg)
        {
            //RouteSend_Assembly(key, msg);
            server.RouteSend(key,msg);
        }


        public bool InitSocket_Assembly()
        {
            AssemblyHandler handler = new AssemblyHandler();
            string assemblyName = @"ClientLib.dll";
            string className = @"ClientLib.GateServer";
            objInfo = handler.GetCSharpClassObj(assemblyName, className);
            if (objInfo == null)
            {
                return false;
            }
            return true;

        }


        void Connect_Assembly()
        {
            if (objInfo == null)
            {
                return;
            }
            MethodInfo meth = objInfo.GetType().GetMethod("ReConnect");
            meth.Invoke(objInfo, null);
        }


        void Process_Assembly()
        {
            if (objInfo == null)
            {
                return;
            }
            MethodInfo meth = objInfo.GetType().GetMethod("Process");
            meth.Invoke(objInfo, null);
        }



        public object RouteInit_Assembly(string key)
        {
            if (objInfo == null)
            {
                return null;
            }
            object[] parameters = new object[] { key };
            MethodInfo meth = objInfo.GetType().GetMethod("RouteInit");
            return meth.Invoke(objInfo, parameters);
        }

        public object RouteGet_Assembly(string key)
        {
            if (objInfo == null)
            {
                return null;
            }
            object[] parameters = new object[] { key };
            MethodInfo meth = objInfo.GetType().GetMethod("RouteGet");
            return meth.Invoke(objInfo, parameters);
        }


        public void RouteSend_Assembly(string key, object msg)
        {
            if (objInfo == null)
            {
                return;
            }
            object[] parameters = new object[] { key, msg };
            MethodInfo meth = objInfo.GetType().GetMethod("RouteSend");
            meth.Invoke(objInfo, parameters);
        }


        public void ExitSocket_Assembly()
        {
            if (objInfo == null)
            {
                return;
            }
            MethodInfo meth = objInfo.GetType().GetMethod("Exit");
            meth.Invoke(objInfo, null);
        }


    }
}
