using System;
using UtilityLib;

namespace CommonLibs
{
    partial class Program
    {
        static void Main(string[] args)
        {
            PathExt.InitPath();
            TestXml();

            string str = "";
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("{0}", str);
            }

            Console.ReadKey();
        }
    }
}
