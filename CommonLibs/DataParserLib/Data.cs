using System;
using System.Collections.Generic;

namespace DataParserLib
{
    public class Data
    {
        private int _id;
        private string _name;
        private string _group;

        private readonly Dictionary<string, Attribute> _attributes;

        public int Id { get => _id;}
        public string Name { get => _name; }
        public string Group { get => _group;}

        public delegate void PropertyCallback(Attribute property);

        public Data()
        {
            _attributes = new Dictionary<string, Attribute>();
        }

        public static bool StringIsNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value)||string.Empty == value)
            {
                return true;
            }
            return false;
        }

        internal bool SetAttribute(Attribute attr)
        {
            Attribute temp;
            if (_attributes.TryGetValue(attr.Key,out temp))
            {
                return false;
            }
            else
            {
                _attributes.Add(attr.Key, attr);
                return true;
            }
        }

        internal void SetId(int id)
        {
            _id = id;
        }
        internal void SetName(string name)
        {
            _name = name;
        }
        internal void SetGroup(string group)
        {
            _group = group;
        }
    }
}
