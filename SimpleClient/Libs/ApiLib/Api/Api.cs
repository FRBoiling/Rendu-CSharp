using AssemblyLib;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ApiLib
{
    public partial class Api
    {
        Dictionary<string, MethodInfo> methods = new Dictionary<string, MethodInfo>();
        object mApi;
        public Api()
        {
            string assemblyName = @"ClientLib.dll";

            Assembly assembly = AssemblyHandler.LoadCSharpAssembly(assemblyName);
            mApi = AssemblyHandler.ActionAssembly(assembly, "ClientLib.GateServer");
            methods.Clear();
            MethodInfo meth = mApi.GetType().GetMethod("Init");
            methods.Add("Init", meth);
            meth = mApi.GetType().GetMethod("Exit");
            methods.Add("Exit", meth);
            meth = mApi.GetType().GetMethod("ReConnect");
            methods.Add("ReConnect", meth);
            meth = mApi.GetType().GetMethod("Process");
            methods.Add("Process", meth);
            meth = mApi.GetType().GetMethod("RouteInit");
            methods.Add("RouteInit", meth);
            meth = mApi.GetType().GetMethod("RouteGet");
            methods.Add("RouteGet", meth);
            meth = mApi.GetType().GetMethod("RouteSend");
            methods.Add("RouteSend", meth);
            //meth = mApi.GetType().GetMethod("Login_Request_MSG_CG_USER_LOGIN");
            //methods.Add("Login_Request_MSG_CG_USER_LOGIN", meth);
        }

        public void Init(string v1, ushort v2)
        {
            MethodInfo meth = methods["Init"];
            object[] parameters = new object[] { v1, v2 };
            meth.Invoke(mApi, parameters);
        }

        public void Exit()
        {
            MethodInfo meth = methods["Exit"];
            //MethodInfo meth = client.GetType().GetMethod("Exit");
            meth.Invoke(mApi, null);
        }

        public bool ReConnect()
        {
            MethodInfo meth = methods["ReConnect"];
            //MethodInfo meth = client.GetType().GetMethod("IsConnected");
            return Convert.ToBoolean(meth.Invoke(mApi, null));
        }

        public void Process()
        {
            MethodInfo meth = methods["Process"];
            //MethodInfo meth = client.GetType().GetMethod("Update");
            meth.Invoke(mApi, null);
        }

        public object RouteInit(string key)
        {
            MethodInfo meth = methods["RouteInit"];
            //MethodInfo meth = client.GetType().GetMethod("RouteInit");
            object[] parameters = new object[] { key };
            return meth.Invoke(mApi, parameters);
        }

        public object RouteGet(string key)
        {
            MethodInfo meth = methods["RouteGet"];
            //MethodInfo meth = client.GetType().GetMethod("RouteGet");
            object[] parameters = new object[] { key };
            return meth.Invoke(mApi, parameters);
        }

        public void RouteSend(string key, object msg)
        {
            MethodInfo meth = methods["RouteSend"];
            //MethodInfo meth = client.GetType().GetMethod("RouteSend");
            object[] parameters = new object[] { key, msg };
            meth.Invoke(mApi, parameters);
        }

        public void Login_Request_MSG_CG_USER_LOGIN()
        {
            MethodInfo meth = methods["Login_Request_MSG_CG_USER_LOGIN"];
            //MethodInfo meth = client.GetType().GetMethod("Request_MSG_CG_USER_LOGIN");
            meth.Invoke(mApi, null);
        }

    }
}
