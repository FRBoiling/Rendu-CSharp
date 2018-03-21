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
using Message.Client.Gate.Protocol.CG;
using Message.Gate.Client.Protocol.GC;
using Engine.Foundation;
using GenerateCodeLib;
using CryptoLib;
namespace ClientLib
{
public partial class GateServer
{
MSG_C2G_HEARTBEAT msg_MSG_C2G_HEARTBEAT;

public object Init_MSG_C2G_HEARTBEAT()
{
msg_MSG_C2G_HEARTBEAT = new MSG_C2G_HEARTBEAT();
return msg_MSG_C2G_HEARTBEAT;
}
public object Get_MSG_C2G_HEARTBEAT()
{
return msg_MSG_C2G_HEARTBEAT;
}
public object New_MSG_C2G_HEARTBEAT()
{
return msg_MSG_C2G_HEARTBEAT;
}
public void OnResponse_MSG_C2G_HEARTBEAT(MemoryStream stream,int uid =0)
{
MSG_C2G_HEARTBEAT MSG_C2G_HEARTBEAT = ProtoBuf.Serializer.Deserialize<MSG_C2G_HEARTBEAT>(stream);
Parser.Parse(MSG_C2G_HEARTBEAT);
}

MSG_C2G_GET_ENCRYPTKEY msg_MSG_C2G_GET_ENCRYPTKEY;

public object Init_MSG_C2G_GET_ENCRYPTKEY()
{
msg_MSG_C2G_GET_ENCRYPTKEY = new MSG_C2G_GET_ENCRYPTKEY();
return msg_MSG_C2G_GET_ENCRYPTKEY;
}
public object Get_MSG_C2G_GET_ENCRYPTKEY()
{
return msg_MSG_C2G_GET_ENCRYPTKEY;
}
public object New_MSG_C2G_GET_ENCRYPTKEY()
{
return msg_MSG_C2G_GET_ENCRYPTKEY;
}
public void OnResponse_MSG_C2G_GET_ENCRYPTKEY(MemoryStream stream,int uid =0)
{
MSG_C2G_GET_ENCRYPTKEY MSG_C2G_GET_ENCRYPTKEY = ProtoBuf.Serializer.Deserialize<MSG_C2G_GET_ENCRYPTKEY>(stream);
Parser.Parse(MSG_C2G_GET_ENCRYPTKEY);
}

public object RouteInit(string className)
{
switch (className)
{
case "MSG_C2G_HEARTBEAT":
return Init_MSG_C2G_HEARTBEAT();

case "MSG_C2G_GET_ENCRYPTKEY":
return Init_MSG_C2G_GET_ENCRYPTKEY();


default:
return null;
}
}
public object RouteNew(string className)
{
switch (className)
{
case "MSG_C2G_HEARTBEAT":
return New_MSG_C2G_HEARTBEAT();

case "MSG_C2G_GET_ENCRYPTKEY":
return New_MSG_C2G_GET_ENCRYPTKEY();


default:
return null;
}
}
public object RouteGet(string className)
{
switch (className)
{
case "MSG_C2G_HEARTBEAT":
return Get_MSG_C2G_HEARTBEAT();

case "MSG_C2G_GET_ENCRYPTKEY":
return Get_MSG_C2G_GET_ENCRYPTKEY();


default:
return null;
}
}
public object RouteType(string className)
{
switch (className)
{
case "MSG_C2G_HEARTBEAT":
return typeof(MSG_C2G_HEARTBEAT);

case "MSG_C2G_GET_ENCRYPTKEY":
return typeof(MSG_C2G_GET_ENCRYPTKEY);


default:
return null;
}
}
public void BindResponse()
{

}
public bool RouteSend(string className,object msg)
{
switch (className)
{
case "MSG_C2G_HEARTBEAT":
return Send((MSG_C2G_HEARTBEAT)msg);

case "MSG_C2G_GET_ENCRYPTKEY":
return Send((MSG_C2G_GET_ENCRYPTKEY)msg);


default:
return false;
}
}

}
}

