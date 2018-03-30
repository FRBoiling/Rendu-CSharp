using CryptoUtility;
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
        private string _publicKey;
        public string PublicKey { get => _publicKey; }

        private static string _privateKey;
        public static string PrivateKey { get => _privateKey; }

        static Client()
        {
            try
            {
                FileStream fsRead = new FileStream(@"..\Data\Key\PrivateKey.key", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fsRead);
                _privateKey = sr.ReadLine();

                sr.Close();
                fsRead.Close();
                Log.Info("PrivateKey set success");
            }
            catch (Exception e)
            {
                Log.Error("PrivateKey set error:" + e.ToString());
            }
        }


        private void OnResponse_GetEncryptkey(MemoryStream stream, int uid)
        {
            Log.Debug("recv get encrypt key {0}", _tag.GetServerTagString());
            byte[] cipherKey = new byte[8];
            RNGCryptoServiceProvider keyProvider = new RNGCryptoServiceProvider();
            keyProvider.GetBytes(cipherKey);
            string hexKey = BitConverter.ToString(cipherKey).Replace("-", "");
            SetBlowFish( new BlowFish(hexKey));
            string encryptKey = RSAHelper.EncryptString(hexKey, _privateKey);
            MSG_G2C_EncryptKey response = new MSG_G2C_EncryptKey();
            response.EncryptKey = encryptKey;
            Send(response);
        }

        
    }
}
