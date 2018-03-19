using AssemblyLib;
using System.Collections.Generic;
using System.Reflection;

namespace ApiLib
{
    public partial class Api
    {
        AssemblyHandler handler;
        object objInfo;
 
        public bool InitSocket()
        {
            handler = new AssemblyHandler();
            string assemblyName = @"ClientLib.dll";
            string className = @"ClientLib.GateServer";
            objInfo = handler.GetCSharpClassObj(assemblyName, className);
            if (objInfo == null)
            {
                return false;
            }
            return true;

        }

        private void Connect2GateServer()
        {
            //ushort groupId = server.GetUInt16("GroupId");
            //string ip = server.GetString("Ip");
            //ushort port = server.GetUInt16("Port");
            //ushort subId = server.GetUInt16("SubId");
            ushort groupId = 1;
            ushort subId = 1;
            string ip = "127.0.0.1";
            ushort port = 8201;

            InitConnectInfo(ip,port);

            Connect();
        }

        void InitConnectInfo(string ip, ushort port)
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

        void Connect()
        {
            if (objInfo == null)
            {
                return;
            }
            MethodInfo meth = objInfo.GetType().GetMethod("ReConnect");
            meth.Invoke(objInfo,null);
        }

        void ProcessLogic()
        {
            if (objInfo == null)
            {
                return;
            }
            MethodInfo meth = objInfo.GetType().GetMethod("Process");
            meth.Invoke(objInfo, null);
        }

        public object RouteInit(string key)
        {
            if (objInfo == null)
            {
                return null;
            }
            object[] parameters = new object[] { key };
            MethodInfo meth = objInfo.GetType().GetMethod("RouteInit");
            return meth.Invoke(objInfo, parameters);
        }

        public object RouteGet(string key)
        {
            if (objInfo == null)
            {
                return null;
            }
            object[] parameters = new object[] { key };
            MethodInfo meth = objInfo.GetType().GetMethod("RouteGet");
            return meth.Invoke(objInfo, parameters);
        }

        public void RouteSend(string key,object msg)
        {
            if (objInfo == null)
            {
                return;
            }
            object[] parameters = new object[] { key ,msg};
            MethodInfo meth = objInfo.GetType().GetMethod("RouteSend");
            meth.Invoke(objInfo, parameters);
        }

    }
}
