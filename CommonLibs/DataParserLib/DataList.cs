using System;
using System.Collections;
using System.Collections.Generic;

namespace DataParserLib
{
    public class DataList : IEnumerable<KeyValuePair<int, Data>>
    {
        private string _id;
        private Data _header;

        private Dictionary<int, Data> _dataList;
        private Dictionary<string, Data> _dataListByName;
        private Dictionary<string, List<Data>> _dataListByGroup;

        public DataList()
        {
            _dataList = new Dictionary<int, Data>();
            _dataListByName = new Dictionary<string, Data>();
            _dataListByGroup = new Dictionary<string, List<Data>>();

            _header = new Data();
        }

        public void Init(string id)
        {
            _id = id;
        }

        public IEnumerator<KeyValuePair<int, Data>> GetEnumerator()
        {
            return _dataList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dataList.GetEnumerator();
        }

        public int Count { get => _dataList.Count; }

        public Data Header { get => _header; set => _header = value; }

        public bool Add(Data data)
        {
            if (data == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("data is null!");
                return false;
            }

            Data temp;
            if (_dataList.TryGetValue(data.Id, out temp))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("data '{0}' has duplicated id '{1}'", _id, data.Id);
                return false;
            }

            if (Data.StringIsNull(data.Name))
            {
            }
            else
            {
                if (_dataListByName.TryGetValue(data.Name, out temp))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("data '{0}' has duplicated name '{1}'", _id, data.Id);
                    return false;
                }
                else
                {
                    _dataListByName.Add(data.Name, data);
                }
            }

            _dataList.Add(data.Id, data);

            if (Data.StringIsNull(data.Group))
            {
            }
            else
            {
                List<Data> groupList;
                if (_dataListByGroup.TryGetValue(data.Group, out groupList))
                {
                }
                else
                {
                    groupList = new List<Data>();
                    _dataListByGroup.Add(data.Group, groupList);
                }

                groupList.Add(data);
            }
            return true;
        }

        public Data Get(int id)
        {
            Data data;
            _dataList.TryGetValue(id, out data);
            return data;
        }

        public Data Get(string name)
        {
            Data data;
            _dataListByName.TryGetValue(name, out data);
            return data;
        }

        public List<Data> GetDatasByGroup(string name)
        {
            List<Data> lstData;
            _dataListByGroup.TryGetValue(name, out lstData);
            return lstData;
        }



    }
}
