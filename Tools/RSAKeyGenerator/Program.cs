using CryptoUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAHelper.RSAKey key = RSAHelper.GetRASKey();

            FileStream publicKeyStream = new FileStream(@".\PublicKey.key",FileMode.Create,FileAccess.Write);
            StreamWriter publicKeyWriter = new StreamWriter(publicKeyStream);
            publicKeyWriter.Write(key.PublicKey);
            publicKeyWriter.Close();
            publicKeyStream.Close();


            FileStream privateKeyStream = new FileStream(@".\PrivateKey.key", FileMode.Create, FileAccess.Write);
            StreamWriter privateKeyWriter = new StreamWriter(privateKeyStream);
            privateKeyWriter.Write(key.PrivateKey);
            privateKeyWriter.Close();
            privateKeyStream.Close();

            Console.Write("Key generated");
            Console.ReadLine();
        }
    }
}
