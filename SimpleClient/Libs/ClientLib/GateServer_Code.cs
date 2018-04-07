/******************************************************************************
 * 命名空间: ClientLib                                                        *
 * 类 名：GateServer                                                          *
 *                                                                            *
 * Ver      负责人        变更内容            变更日期                        *
 * ───────────────────────────────────── *
 * V1.0     Boiling     初版                $time$                            *
 *                                                                            *
 * Copyright (c) 2018 Lir Corporation. All rights reserved.                   *
 *┌────────────────────────────────────┐*
 *│　此技术信息为本人机密信息，未经本人书面同意禁止向第三方披露．          │*
 *│　版权所有：BoilingBlood　　　　　　　　　　　　                        │*
 *└────────────────────────────────────┘*
 ******************************************************************************/
using System.IO;
using Protocol.Client.C2G;
using Protocol.Gate.G2C;
using Engine.Foundation;
using GenerateCodeLib;
using CryptoLib;
namespace ClientLib
{
public partial class GateServer
{
public void OnResponse_MSG_G2C_Heartbeat(MemoryStream stream,int uid =0)
{
MSG_G2C_Heartbeat MSG_G2C_Heartbeat = ProtoBuf.Serializer.Deserialize<MSG_G2C_Heartbeat>(stream);
Parser.Parse(MSG_G2C_Heartbeat);
}

public void OnResponse_MSG_G2C_Login(MemoryStream stream,int uid =0)
{
MSG_G2C_Login MSG_G2C_Login = ProtoBuf.Serializer.Deserialize<MSG_G2C_Login>(stream);
Parser.Parse(MSG_G2C_Login);
}

public void OnResponse_MSG_G2C_CreateRole(MemoryStream stream,int uid =0)
{
MSG_G2C_CreateRole MSG_G2C_CreateRole = ProtoBuf.Serializer.Deserialize<MSG_G2C_CreateRole>(stream);
Parser.Parse(MSG_G2C_CreateRole);
}

public void OnResponse_Role_BaseInfo(MemoryStream stream,int uid =0)
{
Role_BaseInfo Role_BaseInfo = ProtoBuf.Serializer.Deserialize<Role_BaseInfo>(stream);
Parser.Parse(Role_BaseInfo);
}

public void OnResponse_Role_Model(MemoryStream stream,int uid =0)
{
Role_Model Role_Model = ProtoBuf.Serializer.Deserialize<Role_Model>(stream);
Parser.Parse(Role_Model);
}

public void OnResponse_Role_Info(MemoryStream stream,int uid =0)
{
Role_Info Role_Info = ProtoBuf.Serializer.Deserialize<Role_Info>(stream);
Parser.Parse(Role_Info);
}

MSG_C2G_Heartbeat msg_MSG_C2G_Heartbeat;

public object Init_MSG_C2G_Heartbeat()
{
msg_MSG_C2G_Heartbeat = new MSG_C2G_Heartbeat();
return msg_MSG_C2G_Heartbeat;
}
public object Get_MSG_C2G_Heartbeat()
{
return msg_MSG_C2G_Heartbeat;
}
public object New_MSG_C2G_Heartbeat()
{
return msg_MSG_C2G_Heartbeat;
}
public void OnResponse_MSG_C2G_Heartbeat(MemoryStream stream,int uid =0)
{
MSG_C2G_Heartbeat MSG_C2G_Heartbeat = ProtoBuf.Serializer.Deserialize<MSG_C2G_Heartbeat>(stream);
Parser.Parse(MSG_C2G_Heartbeat);
}

MSG_C2G_GetEncryptKey msg_MSG_C2G_GetEncryptKey;

public object Init_MSG_C2G_GetEncryptKey()
{
msg_MSG_C2G_GetEncryptKey = new MSG_C2G_GetEncryptKey();
return msg_MSG_C2G_GetEncryptKey;
}
public object Get_MSG_C2G_GetEncryptKey()
{
return msg_MSG_C2G_GetEncryptKey;
}
public object New_MSG_C2G_GetEncryptKey()
{
return msg_MSG_C2G_GetEncryptKey;
}
public void OnResponse_MSG_C2G_GetEncryptKey(MemoryStream stream,int uid =0)
{
MSG_C2G_GetEncryptKey MSG_C2G_GetEncryptKey = ProtoBuf.Serializer.Deserialize<MSG_C2G_GetEncryptKey>(stream);
Parser.Parse(MSG_C2G_GetEncryptKey);
}

MSG_C2G_Login msg_MSG_C2G_Login;

public object Init_MSG_C2G_Login()
{
msg_MSG_C2G_Login = new MSG_C2G_Login();
return msg_MSG_C2G_Login;
}
public object Get_MSG_C2G_Login()
{
return msg_MSG_C2G_Login;
}
public object New_MSG_C2G_Login()
{
return msg_MSG_C2G_Login;
}
public void OnResponse_MSG_C2G_Login(MemoryStream stream,int uid =0)
{
MSG_C2G_Login MSG_C2G_Login = ProtoBuf.Serializer.Deserialize<MSG_C2G_Login>(stream);
Parser.Parse(MSG_C2G_Login);
}

MSG_C2G_CreateRole msg_MSG_C2G_CreateRole;

public object Init_MSG_C2G_CreateRole()
{
msg_MSG_C2G_CreateRole = new MSG_C2G_CreateRole();
return msg_MSG_C2G_CreateRole;
}
public object Get_MSG_C2G_CreateRole()
{
return msg_MSG_C2G_CreateRole;
}
public object New_MSG_C2G_CreateRole()
{
return msg_MSG_C2G_CreateRole;
}
public void OnResponse_MSG_C2G_CreateRole(MemoryStream stream,int uid =0)
{
MSG_C2G_CreateRole MSG_C2G_CreateRole = ProtoBuf.Serializer.Deserialize<MSG_C2G_CreateRole>(stream);
Parser.Parse(MSG_C2G_CreateRole);
}

public object RouteInit(string className)
{
switch (className)
{
case "MSG_C2G_Heartbeat":
return Init_MSG_C2G_Heartbeat();

case "MSG_C2G_GetEncryptKey":
return Init_MSG_C2G_GetEncryptKey();

case "MSG_C2G_Login":
return Init_MSG_C2G_Login();

case "MSG_C2G_CreateRole":
return Init_MSG_C2G_CreateRole();


default:
return null;
}
}
public object RouteNew(string className)
{
switch (className)
{
case "MSG_C2G_Heartbeat":
return New_MSG_C2G_Heartbeat();

case "MSG_C2G_GetEncryptKey":
return New_MSG_C2G_GetEncryptKey();

case "MSG_C2G_Login":
return New_MSG_C2G_Login();

case "MSG_C2G_CreateRole":
return New_MSG_C2G_CreateRole();


default:
return null;
}
}
public object RouteGet(string className)
{
switch (className)
{
case "MSG_C2G_Heartbeat":
return Get_MSG_C2G_Heartbeat();

case "MSG_C2G_GetEncryptKey":
return Get_MSG_C2G_GetEncryptKey();

case "MSG_C2G_Login":
return Get_MSG_C2G_Login();

case "MSG_C2G_CreateRole":
return Get_MSG_C2G_CreateRole();


default:
return null;
}
}
public object RouteType(string className)
{
switch (className)
{
case "MSG_C2G_Heartbeat":
return typeof(MSG_C2G_Heartbeat);

case "MSG_C2G_GetEncryptKey":
return typeof(MSG_C2G_GetEncryptKey);

case "MSG_C2G_Login":
return typeof(MSG_C2G_Login);

case "MSG_C2G_CreateRole":
return typeof(MSG_C2G_CreateRole);


default:
return null;
}
}
public void BindResponse()
{
AddProcesser(Id<MSG_G2C_Heartbeat>.Value, OnResponse_MSG_G2C_Heartbeat);

AddProcesser(Id<MSG_G2C_Login>.Value, OnResponse_MSG_G2C_Login);

AddProcesser(Id<MSG_G2C_CreateRole>.Value, OnResponse_MSG_G2C_CreateRole);

AddProcesser(Id<Role_BaseInfo>.Value, OnResponse_Role_BaseInfo);

AddProcesser(Id<Role_Model>.Value, OnResponse_Role_Model);

AddProcesser(Id<Role_Info>.Value, OnResponse_Role_Info);


}
public bool RouteSend(string className,object msg)
{
switch (className)
{
case "MSG_C2G_Heartbeat":
return Send((MSG_C2G_Heartbeat)msg);

case "MSG_C2G_GetEncryptKey":
return Send((MSG_C2G_GetEncryptKey)msg);

case "MSG_C2G_Login":
return Send((MSG_C2G_Login)msg);

case "MSG_C2G_CreateRole":
return Send((MSG_C2G_CreateRole)msg);


default:
return false;
}
}

}
}

