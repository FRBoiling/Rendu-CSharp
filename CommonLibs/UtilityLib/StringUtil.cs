using System;

namespace UtilityLib
{
    public class StringUtil
    {
        public static string[] ParseArray(string str)
        {
            string[] separator = new string[] { "||" };
            return str.Split(separator, StringSplitOptions.None);
        }


        public static string[] GetSplitString(string source, char split)
        {
            char[] separator = new char[] { split };
            return source.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string GetStringAfterLastOf(string source,string split)
        {
            int startIndex = source.LastIndexOf(split) + 1;
            string str = source.Substring(startIndex, source.Length - startIndex);
            return str;
        }

    }
}
