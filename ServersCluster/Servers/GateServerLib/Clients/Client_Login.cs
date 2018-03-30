using CryptoUtility;
using GateServerLib.Auth;
using LogLib;
using Message.Client.Gate.Protocol.CG;
using Message.Gate.Client.Protocol.GC;
using System;
using System.IO;
using System.Security.Cryptography;
using TcpLib;

namespace GateServerLib
{
    public partial class Client
    {
        AuthManager _authMgr = new AuthManager();

        private void OnResponse_Login(MemoryStream stream, int uid)
        {
            MSG_C2G_Login msg = ProtoBuf.Serializer.Deserialize<MSG_C2G_Login>(stream);
            Log.Debug("recv login usr {0} pwd {1}", msg.Username,msg.Password);

            //Client loginedClient = _manager.FindClient(msg.Username);
            //检查是不是重复登陆
            //if (otherClient!= null)
            {
                //1 重复登陆逻辑
                //frTODO:
                //告诉客户端是重复登陆
                //顶掉loginedClient 做相关清理工作
            }
            //else
            {
                //2 正常登陆逻辑
                //检查版本号
                //检查登陆token
                //检查账号密码
                _authMgr.Username = msg.Username;

            }
        }



        
    }
}
