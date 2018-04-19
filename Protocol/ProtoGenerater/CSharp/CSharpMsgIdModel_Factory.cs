using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoGenerater.CSharp
{
    public partial class CSharpMsgIdModel
    {
        public void CreateIdClassCode()
        {
            StringBuilder idClassCode = GenerateCode_ID();
            string idFileName = "Id.cs";
            string strOutPath = Program.OutputPath + @"CSharp\";
            if (!Directory.Exists(strOutPath))
            {
                Directory.CreateDirectory(strOutPath);
            }
            string idFileFullName = strOutPath + idFileName;
            FileInfo fileInfo = new FileInfo(idFileFullName);
            StreamWriter writer = fileInfo.CreateText();
            writer.WriteLine(idClassCode.ToString());
            writer.Close();
            Console.WriteLine("{0} generate sucess", idFileName);
            Console.WriteLine(">>{0}", idFileFullName);
        }

        public void CreateMsgIdClass(string codeName,string packageName, Dictionary<string, string> keyIdPairs)
        {
            StringBuilder msgIdPairsCode = GenerateCode_GenerateId(packageName, keyIdPairs);

            string tempPath = packageName.Replace('.', '\\');

            string strOutPath = Program.OutputPath + @"CSharp\" + tempPath;
            if (!Directory.Exists(strOutPath))
            {
                Directory.CreateDirectory(strOutPath);
            }
            string csFileFullName = strOutPath + @"\"+ codeName+"Id.cs";

            FileInfo fileInfo = new FileInfo(csFileFullName);
            StreamWriter writer = fileInfo.CreateText();
            writer.WriteLine(msgIdPairsCode.ToString());
            writer.Close();
            int index = csFileFullName.LastIndexOf('\\');
            string csFileName = csFileFullName.Substring(index + 1);
            Console.WriteLine("{0} generate sucess", csFileName);
            Console.WriteLine(">>{0}", csFileFullName);
        }

        public void GenerateProto(string packageName,string importPath)
        {
            string tempPath = packageName.Replace('.', '\\');
            string strOutPath = Program.OutputPath + @"CSharp\" + tempPath;
            if (!Directory.Exists(strOutPath))
            {
                Directory.CreateDirectory(strOutPath);
            }
           // string csFileFullName = strOutPath + "_Proto.cs";

            //调用外部程序protogen.exe
            Process p = new Process();
            //p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.FileName = Application.StartupPath + @"\protogen.exe";
            //p.StartInfo.WorkingDirectory = Application.StartupPath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.Arguments = "-I" + importPath + " *.proto"+ @" --csharp_out=" + strOutPath;// -ns:" + Application.StartupPath;
            p.Start();
            p.StandardInput.WriteLine("exit");

            //p.WaitForExit();
            //string command = Application.StartupPath + @"\protogen.exe -i:" + fileName + @" -o:descriptor.cs -ns:" + Application.StartupPath;
            //p.StandardInput.WriteLine(command);
            //p.StandardInput.WriteLine("exit"); //需要有这句，不然程序会挂机
            // 向cmd.exe输入command
            //string output = p.StandardOutput.ReadToEnd(); 这句可以用来获取执行命令的输出结果
        }

    }
}
