using StackExchange.Redis;
using System;
using System.Text.RegularExpressions;

namespace ServersCluster
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            //ConfigurationOptions config = new ConfigurationOptions();
            //config.ReconnectRetryPolicy = new ExponentialRetry(1000);


            //Regex regChina = new Regex("^[^\x00-\xFF]");
            //Regex regEnglish = new Regex("^[a-zA-Z]");
            //Regex reg = new Regex("^[a-zA-Z0-9\u4e00-\u9fa5]");
            Regex reg = new Regex("^[a-zA-Z0-9_\u4e00-\u9fa5]+$");  //只包含字母数字汉字下划线……【98

            string strNihao  = "你好";
            string strNihao1  = "你hao";
            string strNihao2  = "你hao";

            if (reg.IsMatch(strNihao2))
            {
                Console.WriteLine("------rrrr-------");
            }
          



            Console.WriteLine("-------------");
            float x = (float)0.49;
            Console.WriteLine("-------------");
        }
    }
}
