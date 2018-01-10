using StackExchange.Redis;
using System;

namespace ServersCluster
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            ConfigurationOptions config = new ConfigurationOptions();
            config.ReconnectRetryPolicy = new ExponentialRetry(1000);


            Console.WriteLine("-------------");
            float x = (float)0.49;
            Console.WriteLine("-------------");
        }
    }
}
