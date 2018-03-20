using GenerateCodeLib;
using LogLib;
using System;
using System.CodeDom.Compiler;

namespace GenerateCode
{
    class Program
    {

        static void InitLogger()
        {
            var logger = new ConsoleLogger();
            logger.Init(true, @"..\Log\", "GenerateCode");
            logger.SetLogo("");
#if DEBUG
            logger.SetPriority(4);
#else
            logger.SetPriority(2);
#endif
            Log.InitLog(logger);
            Log.Info("InitLogger successed");
        }

        static void Main(string[] args)
        {
            InitLogger();
            string code = ParseCode.AssemblyParseDll("ClientProtocol.dll");

            //string soure = /*PathExt.workPath + @"\ClientLib\";*/";
            string sourePath = @"..\..\Libs\ClientLib\";
            string str1 = sourePath + @"GateServer.cs";
            string str2 = sourePath + @"GateServer_Code.cs";
            string str3 = sourePath + @"GateServer_Login_Requset.cs";
            string str4 = sourePath + @"GateServer_Login_Response.cs";
            string str5 = sourePath + @"HostInfo.cs";

            string[] files = new string[] { str1, str2, str3, str4, str5 };

            CompilerResults result = ParseCode.DebugRun(files, "ClientLib.dll");
            if (result.Errors.HasErrors)
            {
                Log.Write("编译错误");
                foreach (CompilerError err in result.Errors)
                {
                    Log.Error(err.ErrorText);
                }
            }
            else
            {
                Log.Write("编译成功");
            }

            Console.ReadKey();
        }
    }
}
