using DataParserLib;
using System;

namespace CommonLibs
{
    partial class  Program
    {
        public static void TestXml()
        {
            string filename = "D:\\GitHub\\ServerCluster-master\\Bin\\Data\\Xml\\ServerConfig.xml";
            XmlDataManager.Inst.Parse(filename);

            DataList data = XmlDataManager.Inst.GetDataList("ServerConfig");
            foreach (var item in data)
            {
                Console.WriteLine("key {0} value {1}", item.Key, item.Value.Name);
            }
        }
    }
}
