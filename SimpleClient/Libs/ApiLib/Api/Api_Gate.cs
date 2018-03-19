using AssemblyLib;
#if !ASSEMBLY
using ClientLib;
#endif
using System.Collections.Generic;
using System.Reflection;

namespace ApiLib
{
    public partial class Api
    {
#if ASSEMBLY
        object objInfo;
#else
        GateServer server;
#endif

        public bool InitSocket()
        {
#if ASSEMBLY
            return InitSocket_Assembly();
#else
            server = new GateServer();
            return true;
#endif
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
#if ASSEMBLY
            InitConnectInfo_Assembly(ip, port);
#else
            server.InitConnectInfo(ip, port);
#endif
        }


        public void ExitSocket()
        {
#if ASSEMBLY
            ExitSocket_Assembly();
#else
            server.Exit();
#endif      
        }

        public void ReConnect()
        {
#if ASSEMBLY
            Connect_Assembly();
#else
            server.ReConnect();
#endif      
        }


        void ProcessLogic()
        {
#if ASSEMBLY
            Process_Assembly();
#else
            server.Process();
#endif      
        }

        public object RouteInit(string key)
        {
#if ASSEMBLY
            return RouteInit_Assembly(key);
#else
            return server.RouteInit(key);
#endif      
        }

        public object RouteGet(string key)
        {
#if ASSEMBLY
            return RouteGet_Assembly(key);
#else
            return server.RouteGet(key);
#endif      
        }

        public void RouteSend(string key, object msg)
        {
#if ASSEMBLY
           RouteSend_Assembly(key, msg);
#else
            server.RouteSend(key,msg);
#endif      
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

        void InitConnectInfo_Assembly(string ip, ushort port)
        {
            if (objInfo == null)
            {
                return;
            }

            object[] parameters = new object[] { ip, port };
            MethodInfo meth = objInfo.GetType().GetMethod("InitConnectInfo");
            meth.Invoke(objInfo, parameters);
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
