using LogLib;
using System;
using System.Collections;
using System.Reflection;

namespace GenerateCodeLib
{
    public struct PropertyType
    {
        public const string Int32 = "Int32";
        public const string UInt64 = "UInt64";
        public const string String = "String";
        public const string List = "List`1";
        public const string Float = "Single";
        public const string Bool = "Boolean";
    }


    public static class Parser
    {
        public struct SpaceString
        {
            public const string Space = "    ";
        }

        public static void Parse(object msg)
        {
            if (msg == null)
            {
                Log.Error("Parse got an error: msg = null");
                return;
            }
            Type type = msg.GetType();
            PropertyInfo[] propertyinfo = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            string linePrefix = string.Format("{0}{1}", SpaceString.Space, "*>");
            string parseHead = string.Format("{0}<<<<<<<<<<< Recv {1} <<<<<<<<<{2}", Environment.NewLine, type.Name, Environment.NewLine);
            string parseMiddle = "";
            string parseEnd = ">>>>>>>>>>>>>>>>>>>>>>>>>>";

            foreach (var item in propertyinfo)
            {
                string propertyType = item.PropertyType.Name;
                string propertyName = item.Name;
                object value = item.GetValue(msg, null);

                switch (propertyType)
                {
                    case PropertyType.Int32:
                    case PropertyType.UInt64:
                    case PropertyType.Float:
                    case PropertyType.Bool:
                    case PropertyType.String:
                        {
                            parseMiddle = ParseNormalTypeObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                    case PropertyType.List:
                        {
                            parseMiddle = ParseListObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                    default:
                        {
                            parseMiddle = ParseCustomObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                }
            }
            Log.Write("{0}{1}{2}>>>>>>>>>>>>>>>>>>>>>>>>>>", parseHead, parseMiddle, parseEnd);
        }



        public static string ParseToString(object msg,string prefix,string name ="")
        {
            if (msg ==null)
            {
                //Log.ErrorLine("ParseToString got an error: msg = null");
                return string.Empty;
            }
       
            Type type = msg.GetType();
            string linePrefix = string.Format("{0}{1}", SpaceString.Space, prefix);
            string parseHead = "";
            if (name!="")
            {
                parseHead = string.Format("{0}{1} {2}{3}", linePrefix, type.Name, name, Environment.NewLine);
                linePrefix = string.Format("{0}{1}", SpaceString.Space, linePrefix);
            }
            string parseMiddle = "";
            //string parseEnd = string.Format("{0}{1}", linePrefix,Environment.NewLine);
            string parseEnd ="";
            switch (type.Name)
            {
                case PropertyType.Int32:
                case PropertyType.UInt64:
                case PropertyType.Float:
                case PropertyType.Bool:
                case PropertyType.String:
                    {
                        parseHead = "";
                        parseMiddle = ParseNormalTypeObject(linePrefix, parseMiddle, type.Name, name, msg);
                        return string.Format("{0}{1}{2}", parseHead, parseMiddle, parseEnd);
                    }
                case PropertyType.List:
                    {
                        parseEnd = Environment.NewLine;
                        parseMiddle = ParseListObject(linePrefix, parseMiddle, type.Name, name, msg);
                        return string.Format("{0}{1}{2}", parseHead, parseMiddle, parseEnd);
                    }
                default:
                    break;
            }

            PropertyInfo[] propertyinfo = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var item in propertyinfo)
            {
                string propertyType = item.PropertyType.Name;
                string propertyName = item.Name;
                object value = item.GetValue(msg, null);

                switch (propertyType)
                {
                    case PropertyType.Int32:
                    case PropertyType.UInt64:
                    case PropertyType.Float:
                    case PropertyType.Bool:
                    case PropertyType.String:
                        {
                            parseMiddle = ParseNormalTypeObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                    case PropertyType.List:
                        {
                            parseMiddle = ParseListObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                    default:
                        {
                            parseMiddle = ParseCustomObject(linePrefix, parseMiddle, propertyType, propertyName, value);
                        }
                        break;
                }
            }
            return string.Format("{0}{1}{2}", parseHead, parseMiddle, parseEnd);
        }

        private static string ParseCustomObject(string linePrefix, string parseMiddle, string propertyType, string propertyName, object value)
        {
            string parseMiddleSon = "";
            if (value==null)
            {
                parseMiddleSon = string.Format("{0}{1} {2} = {3}{4}", linePrefix, propertyType, propertyName, "null", Environment.NewLine);
            }
            else
            {
                parseMiddleSon = string.Format("{0}{1} {2} = {3}{4}", linePrefix, propertyType, propertyName, value, Environment.NewLine);
            }
            parseMiddle = string.Format("{0}{1}", parseMiddle, parseMiddleSon);
            parseMiddleSon = ParseToString(value, linePrefix);
            parseMiddle = string.Format("{0}{1}", parseMiddle, parseMiddleSon);
            return parseMiddle;
        }

        private static string ParseNormalTypeObject(string linePrefix, string parseMiddle, string propertyType, string propertyName, object value)
        {
            string parseMiddleSon = "";
            if (value == null)
            {
                parseMiddleSon = string.Format("{0}{1} {2} = {3}{4}", linePrefix, propertyType, propertyName, "null", Environment.NewLine);
            }
            else
            {
                parseMiddleSon = string.Format("{0}{1} {2} = {3}{4}", linePrefix, propertyType, propertyName, value, Environment.NewLine);
            }
           
            parseMiddle = string.Format("{0}{1}", parseMiddle, parseMiddleSon);
            return parseMiddle;
        }

        private static string ParseListObject(string linePrefix, string parseMiddle, string propertyType, string propertyName, object value)
        {
            if (value == null)
            {
                Log.Error("ParseListObject got an error: value = null");
            }
            Type tt= value.GetType();
            IEnumerable it = value as IEnumerable;
            int index = 0;
            string parseMiddleSon = string.Empty;
            foreach (var obj in it)
            {
                string itName = GetListPropertyName(propertyName, index);
                string sonShow = ParseToString(obj, linePrefix, itName);
                parseMiddleSon = string.Format("{0}{1}", parseMiddleSon, sonShow);
                index++;
            }
            string strListHeader = string.Format("{0}{1} {2} = {3}(count:{4}){5}", linePrefix, propertyType, propertyName, value, index, Environment.NewLine);
            parseMiddle = string.Format("{0}{1}",  parseMiddle, strListHeader);
            parseMiddle = string.Format("{0}{1}", parseMiddle, parseMiddleSon);
            return parseMiddle;
        }

        private static string GetListPropertyName(string propertyName, int index)
        {
            return string.Format("{0}[{1}]", propertyName, index);
        }
    }
}
