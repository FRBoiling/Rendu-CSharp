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
            string fileName = "";
            string codeFileFullName = @"..\..\Bin\" + codeFileName;
            FileInfo fCodeFileName = new FileInfo(codeFileFullName);
            StreamWriter wResponseRecv = fCodeFileName.CreateText();
            wResponseRecv.WriteLine(strGenerateCode.ToString());
            wResponseRecv.Close();

            string[] files = Directory.GetFiles(@"..\..\..\", "*.code", SearchOption.AllDirectories);
            StringBuilder protoCode = new StringBuilder();
            string packageName = "Protocol.Client.C2G";
            Dictionary<string, string> dicMsg = new Dictionary<string, string>();

            foreach (var file in files)
            {
                int index = file.LastIndexOf("\\");
                codeFileName = file.Substring(index + 1);

                IEnumerable<string> lines = File.ReadAllLines(file);

                protoCode.Clear();
                dicMsg.Clear();

                foreach (string line in lines)
                {
                    string strProtoline = "";

                    if (line.StartsWith("package"))
                    {
                        strProtoline = line;
                        protoCode.Append(strProtoline);
                        protoCode.Append(Environment.NewLine);

                        index = line.IndexOf(" ");
                        packageName = line.Substring(index);
                        packageName = packageName.Replace(" ", "");
                        packageName = packageName.Replace(";", "");
                    }
                    else if (line.StartsWith("message"))
                    {
                        strProtoline = line;
                        var arr = strProtoline.Split(' ');
                        List<string> strFormat = new List<string>();
                        if (arr.Length > 2)
                        {
                            foreach (var v in arr)
                            {
                                if (v == " ")
                                {
                                }
                                else
                                {
                                    strFormat.Add(v);
                                }
                            }
                            if (strFormat.Count == 3)
                            {
                                if (arr[0] == "message")
                                {
                                    dicMsg.Add(arr[1], arr[2]);
                                    strProtoline = strProtoline.Replace(arr[2], "");
                                    protoCode.Append(Environment.NewLine);
                                    protoCode.Append(strProtoline);
                                    protoCode.Append(Environment.NewLine);
                                }
                            }
                        }
                    }
                    else if (line.StartsWith("//"))
                    {
                    }
                    else
                    {
                        strProtoline = line;
                        if (string.IsNullOrEmpty(strProtoline)||string.IsNullOrWhiteSpace(strProtoline))
                        {
                        }
                        else
                        {
                            protoCode.Append(strProtoline);
                            protoCode.Append(Environment.NewLine);
                        }
                    }
                }

                strGenerateCode = idModel.GenerateCode_GenerateId(packageName, dicMsg);
                fileName = codeFileName + ".cs";
                codeFileFullName = @"..\..\Bin\\" + fileName;
                fCodeFileName = new FileInfo(codeFileFullName);
                wResponseRecv = fCodeFileName.CreateText();
                wResponseRecv.WriteLine(strGenerateCode.ToString());
                wResponseRecv.Close();

                strGenerateCode = protoCode;
                fileName = codeFileName + ".proto";
                codeFileFullName = @"..\..\Bin\\" + fileName;
                fCodeFileName = new FileInfo(codeFileFullName);
                wResponseRecv = fCodeFileName.CreateText();
                wResponseRecv.WriteLine(strGenerateCode.ToString());
                wResponseRecv.Close();
            }




        }
    }
}
