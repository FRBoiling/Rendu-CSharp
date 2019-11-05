using System;
using System.Linq;
using System.Text;

namespace DesperateDevs.Utils
{
    public static class StringExtension
    {
        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string LowercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string ToUnixLineEndings(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n");
        }

        public static string ToUnixPath(this string str)
        {
            return str.Replace("\\", "/");
        }

        public static string ToCSV(this string[] values)
        {
            return string.Join(", ", values.Where(value => !string.IsNullOrEmpty(value)).Select(value => value.Trim()).ToArray());
        }

        public static string[] ArrayFromCSV(this string values)
        {
            return values.Split(new char[1]
            {
                ','
            }, StringSplitOptions.RemoveEmptyEntries).Select(value => value.Trim()).ToArray();
        }

        public static string ToSpacedCamelCase(this string text)
        {
            var stringBuilder = new StringBuilder(text.Length * 2);
            stringBuilder.Append(char.ToUpper(text[0]));
            for (var index = 1; index < text.Length; ++index)
            {
                if (char.IsUpper(text[index]) && text[index - 1] != ' ')
                    stringBuilder.Append(' ');
                stringBuilder.Append(text[index]);
            }

            return stringBuilder.ToString();
        }

        public static string MakePathRelativeTo(this string path, string currentDirectory)
        {
            currentDirectory = currentDirectory.CreateUri();
            path = path.CreateUri();
            if (path.StartsWith(currentDirectory))
            {
                path = path.Replace(currentDirectory, string.Empty);
                if (path.StartsWith("/"))
                    path = path.Substring(1);
            }

            return path;
        }

        public static string CreateUri(this string path)
        {
            var uri = new Uri(path);
            return Uri.UnescapeDataString(uri.AbsolutePath + uri.Fragment);
        }
    }
}