using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DesperateDevs.Utils;

namespace DesperateDevs.Serialization
{
    public class Properties
    {
        private const string placeholderPattern = "\\${(.+?)}";
        private readonly Dictionary<string, string> _dict;
        private bool _isDoubleQuoteMode;

        public Properties()
            : this(string.Empty)
        {
        }

        public Properties(string properties)
        {
            properties = properties.ToUnixLineEndings();
            _dict = new Dictionary<string, string>();
            addProperties(mergeMultilineValues(getLinesWithProperties(properties)));
        }

        public Properties(Dictionary<string, string> properties)
        {
            _dict = new Dictionary<string, string>(properties);
        }

        public string[] keys => _dict.Keys.ToArray();

        public string[] values => _dict.Values.ToArray();

        public int count => _dict.Count;

        public bool doubleQuoteMode
        {
            get => _isDoubleQuoteMode;
            set
            {
                _isDoubleQuoteMode = value;
                foreach (var index in _dict.Keys.ToArray())
                    this[index] = this[index];
            }
        }

        public string this[string key]
        {
            get
            {
                var str = Regex.Replace(_dict[key], "\\${(.+?)}", match =>
                {
                    var key1 = match.Groups[1].Value;
                    if (!_dict.ContainsKey(key1))
                        return "${" + key1 + "}";
                    return _dict[key1];
                });
                if (!_isDoubleQuoteMode)
                    return str;
                return removeDoubleQuotes(str);
            }
            set
            {
                var str = unescapedSpecialCharacters(value.Trim());
                _dict[key.Trim()] = _isDoubleQuoteMode ? addDoubleQuotes(str) : str;
            }
        }

        public bool HasKey(string key)
        {
            return _dict.ContainsKey(key);
        }

        public void AddProperties(Dictionary<string, string> properties, bool overwriteExisting)
        {
            foreach (var property in properties)
                if (overwriteExisting || !HasKey(property.Key))
                    this[property.Key] = property.Value;
        }

        public void RemoveProperty(string key)
        {
            _dict.Remove(key);
        }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>(_dict);
        }

        private void addProperties(string[] lines)
        {
            var keyValueDelimiter = new char[1] {'='};
            foreach (var strArray in lines.Select(line => line.Split(keyValueDelimiter, 2)))
            {
                if (strArray.Length != 2)
                    throw new InvalidKeyPropertiesException(strArray[0]);
                this[strArray[0]] = strArray[1];
            }
        }

        private static string[] getLinesWithProperties(string properties)
        {
            var separator = new char[1] {'\n'};
            return properties.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(line => line.TrimStart(' '))
                .Where(line => !line.StartsWith("#", StringComparison.Ordinal)).ToArray();
        }

        private static string[] mergeMultilineValues(string[] lines)
        {
            var currentProperty = string.Empty;
            return lines.Aggregate(new List<string>(), (acc, line) =>
            {
                currentProperty += line;
                if (currentProperty.EndsWith("\\", StringComparison.Ordinal))
                {
                    currentProperty = currentProperty.Substring(0, currentProperty.Length - 1);
                }
                else
                {
                    acc.Add(currentProperty);
                    currentProperty = string.Empty;
                }

                return acc;
            }).ToArray();
        }

        private static string escapedSpecialCharacters(string str)
        {
            return str.Replace("\n", "\\n").Replace("\t", "\\t");
        }

        private static string unescapedSpecialCharacters(string str)
        {
            return str.Replace("\\n", "\n").Replace("\\t", "\t");
        }

        private static string addDoubleQuotes(string str)
        {
            if (!isInDoubleQuotes(str))
                return "\"" + str + "\"";
            return str;
        }

        private static string removeDoubleQuotes(string str)
        {
            if (!isInDoubleQuotes(str))
                return str;
            return str.Substring(1, str.Length - 2);
        }

        private static bool isInDoubleQuotes(string str)
        {
            if (str.StartsWith("\""))
                return str.EndsWith("\"");
            return false;
        }

        private static string propertyPair(string key, string value, bool minified)
        {
            if (minified)
                return key + "=" + value;
            return key + " = " + value;
        }

        public override string ToString()
        {
            return _dict.Aggregate(string.Empty, (properties, kv) =>
            {
                var array = escapedSpecialCharacters(kv.Value).ArrayFromCSV().Select(value => value.PadLeft(kv.Key.Length + 3 + value.Length)).ToArray();
                var str = string.Join(", \\\n", array).TrimStart();
                return properties + propertyPair(kv.Key, str, false) + (array.Length > 1 ? "\n\n" : "\n");
            });
        }

        public string ToMinifiedString()
        {
            return _dict.Aggregate(string.Empty, (properties, kv) =>
            {
                var str = escapedSpecialCharacters(kv.Value);
                return properties + propertyPair(kv.Key, str, true) + "\n";
            });
        }
    }
}