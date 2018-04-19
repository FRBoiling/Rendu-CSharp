using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoGenerater
{
    public class CodeFileParser
    {
        Dictionary<string, Dictionary<string, string>> keyIds = new Dictionary<string, Dictionary<string, string>>();
        string protoFile = string.Empty; 

        public void ParsingCodeFile(string file, string outputPath)
        {
            //string[] files = Directory.GetFiles(@"..\..\..\", "*.code", SearchOption.AllDirectories);

            //foreach (var file in files)
            {
                int index = file.LastIndexOf("\\");
                string codeFileName = file.Substring(index + 1);

                string packageName = "Protocol.Client.C2G";
                StringBuilder protoCode = new StringBuilder();
                Dictionary<string, string> keyIdPairs = new Dictionary<string, string>();

                IEnumerable<string> lines = File.ReadAllLines(file);

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
                                    keyIdPairs.Add(arr[1], arr[2]);
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
                        if (string.IsNullOrEmpty(strProtoline) || string.IsNullOrWhiteSpace(strProtoline))
                        {
                        }
                        else
                        {
                            protoCode.Append(strProtoline);
                            protoCode.Append(Environment.NewLine);
                        }
                    }
                }
                if (keyIds.ContainsKey(packageName))
                {
                    Console.WriteLine("file {0} package {1}", file, packageName);
                }
                else
                {
                    keyIds.Add(packageName, keyIdPairs);
                }

                //生产.proto文件
                index = codeFileName.LastIndexOf(".");
                codeFileName = codeFileName.Substring(0, index);
                string protoFileName = codeFileName + @".proto";
                string strOutPath = outputPath + @"Proto\";
                if (!Directory.Exists(strOutPath))
                {
                    Directory.CreateDirectory(strOutPath);
                }
                string protoFileFullName = strOutPath + protoFileName;
                FileInfo fileInfo = new FileInfo(protoFileFullName);
                StreamWriter writer = fileInfo.CreateText();
                writer.WriteLine(protoCode.ToString());
                writer.Close();
                //Console.WriteLine("file {0} package {1} protoFileName {2}", file, packageName, codeFileFullName);
                Console.WriteLine("{0} generate sucess", protoFileName);
                Console.WriteLine(">>{0}", protoFileFullName);
          
                protoFile= protoFileFullName;
              
            }
        }

        public Dictionary<string, Dictionary<string, string>> GetKeyIdPairs()
        {
            return keyIds;
        }

        public string GetProtoFullFileName()
        {
            return protoFile;
        }

    }
}
