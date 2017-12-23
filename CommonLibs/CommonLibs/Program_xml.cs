using DataParserLib;
using System;
using System.IO;
using UtilityLib;

namespace CommonLibs
{
    partial class  Program
    {
        public static void TestXml()
        {
            //string filename = "D:\\GitHub\\ServerCluster-master\\Bin\\Data\\Xml\\ServerConfig.xml";
            string[] files = Directory.GetFiles(PathExt.FullPathFromData("XML"), "*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                XmlDataManager.Inst.Parse(file);
            }

            DataList data = XmlDataManager.Inst.GetDataList("ServerConfig");
            foreach (var item in data)
            {
                Console.WriteLine("key {0} value {1}", item.Key, item.Value.Name);
            }

            data = XmlDataManager.Inst.GetDataList("RedisConfig");
            foreach (var item in data)
            {
                Console.WriteLine("key {0} value {1}", item.Key, item.Value.Name);
            }

        }
    }
}
