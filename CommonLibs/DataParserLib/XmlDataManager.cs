using System.Collections.Generic;
using UtilityLib;

namespace DataParserLib
{
    public class XmlDataManager:Singleton<XmlDataManager>
    {
        private XmlParser _parser;

        private Dictionary<string, DataList> _dataLists;

        public XmlDataManager()
        {
            _parser = new XmlParser();
            _dataLists = new Dictionary<string, DataList>();
        }

        public bool Parse(string filename)
        {
            DataList dataList = _parser.Parse(filename);
            DataList temp;
            if (dataList == null)
            {
                return false;
            }
            else if(_dataLists.TryGetValue(dataList.Id,out temp))
            {
                return true;
            }
            else
            {
                _dataLists.Add(dataList.Id, dataList);
                return true;
            }
        }

        public DataList GetDataList(string idspaceId)
        {
            DataList dataList;
            _dataLists.TryGetValue(idspaceId, out dataList);
            return dataList;
        }

        public Data GetData(string idspaceId, int classId)
        {
            Data data = null;
            DataList datalist = GetDataList(idspaceId);
            if (datalist !=null)
            {
                data = datalist.Get(classId);
            }
            return data;
        }

        public Data GetData(string idspaceId,string className)
        {
            Data data = null;
            DataList datalist = GetDataList(idspaceId);
            if (datalist != null)
            {
                data = datalist.Get(className);
            }
            return data;
        }
        
    }
}
