using DataParserLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "D:\\GitHub\\ServerCluster-master\\Bin\\Data\\Xml\\ServerConfig.xml";
            XmlDataManager.Inst.Parse(filename);

            DataList data = XmlDataManager.Inst.GetDataList("ServerConfig");
            foreach (var item in data)
            {
                Console.WriteLine("key {0} value {1}", item.Key, item.Value.Name);
            }

            Console.ReadKey();
        }
    }
}
