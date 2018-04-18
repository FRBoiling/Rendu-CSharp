using ProtoGenerater.CSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpMsgIdModel idModel = new CSharpMsgIdModel();
            StringBuilder strGenerateCode = idModel.GenerateCode_ID();
            string codeFileName = "Id.cs";
            string codeFileFullName = @"..\..\Bin\" + codeFileName;
            FileInfo fCodeFileName = new FileInfo(codeFileFullName);
            StreamWriter wResponseRecv = fCodeFileName.CreateText();
            wResponseRecv.WriteLine(strGenerateCode.ToString());
            wResponseRecv.Close();

            string[] files = Directory.GetFiles(@"..\..\Bin\", "*.code", SearchOption.AllDirectories);

            string packageName = "Protocol.Client.C2G";
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();
            foreach (var item in files)
            {
                string[] lines = File.ReadAllLines(item);
                foreach (string line in lines)
                {
                    int index = line.IndexOf(" ");
                    if (index >0)
                    {
                        string key = line.Substring(0, index);
                        if ("package" == key)
                        {
                            packageName = line.Substring(index);
                            packageName = packageName.Replace(";", "");
                        }
                        else if ("message" == key)
                        {
                            string messageNameAndId = line.Substring(index+1);
                            var arr = messageNameAndId.Split(' ');
                            if (arr.Length > 1)
                            {
                                dicMsg.Add(arr[0], arr[1]);
                            }
                        }
                    }
                }
            }
     
            strGenerateCode = idModel.GenerateCode_GenerateId(packageName,dicMsg);
            codeFileName = "CG.code.cs";
            codeFileFullName = @"..\..\Bin\" + codeFileName;
            fCodeFileName = new FileInfo(codeFileFullName);
            wResponseRecv = fCodeFileName.CreateText();
            wResponseRecv.WriteLine(strGenerateCode.ToString());
            wResponseRecv.Close();
        }
    }
}
