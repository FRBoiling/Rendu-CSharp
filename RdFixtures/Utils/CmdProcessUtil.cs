using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Rd.Utils
{
    public static class CmdProcessUtil
    {
        public static void RunCmdProcess(string fileName, string strParams, string workDirectory)
        {
            var p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.WorkingDirectory = workDirectory;
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.StartInfo.Arguments = strParams;
            p.Start();
            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            Console.WriteLine(output);
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

    }
}
