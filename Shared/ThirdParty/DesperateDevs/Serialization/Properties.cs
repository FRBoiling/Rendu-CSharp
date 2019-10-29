using DesperateDevs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesperateDevs.Serialization
{
  public class Properties
  {
    private const string placeholderPattern = "\\${(.+?)}";
    private bool _isDoubleQuoteMode;
    private readonly Dictionary<string, string> _dict;

    public string[] keys
    {
      get
      {
        return this._dict.Keys.ToArray<string>();
      }
    }

    public string[] values
    {
      get
      {
        return this._dict.Values.ToArray<string>();
      }
    }

    public int count
    {
      get
      {
        return this._dict.Count;
      }
    }

    public bool doubleQuoteMode
    {
      get
      {
        return this._isDoubleQuoteMode;
      }
      set
      {
        this._isDoubleQuoteMode = value;
        foreach (string index in this._dict.Keys.ToArray<string>())
          this[index] = this[index];
      }
    }

    public string this[string key]
    {
      get
      {
        string str = Regex.Replace(this._dict[key], "\\${(.+?)}", (MatchEvaluator) (match =>
        {
          string key1 = match.Groups[1].Value;
          if (!this._dict.ContainsKey(key1))
            return "${" + key1 + "}";
          return this._dict[key1];
        }));
        if (!this._isDoubleQuoteMode)
          return str;
        return Properties.removeDoubleQuotes(str);
      }
      set
      {
        string str = Properties.unescapedSpecialCharacters(value.Trim());
        this._dict[key.Trim()] = this._isDoubleQuoteMode ? Properties.addDoubleQuotes(str) : str;
      }
    }

    public Properties()
      : this(string.Empty)
    {
    }

    public Properties(string properties)
    {
      properties = properties.ToUnixLineEndings();
      this._dict = new Dictionary<string, string>();
      this.addProperties(Properties.mergeMultilineValues(Properties.getLinesWithProperties(properties)));
    }

    public Properties(Dictionary<string, string> properties)
    {
      this._dict = new Dictionary<string, string>((IDictionary<string, string>) properties);
    }

    public bool HasKey(string key)
    {
      return this._dict.ContainsKey(key);
    }

    public void AddProperties(Dictionary<string, string> properties, bool overwriteExisting)
    {
      foreach (KeyValuePair<string, string> property in properties)
      {
        if (overwriteExisting || !this.HasKey(property.Key))
          this[property.Key] = property.Value;
      }
    }

    public void RemoveProperty(string key)
    {
      this._dict.Remove(key);
    }

    public Dictionary<string, string> ToDictionary()
    {
      return new Dictionary<string, string>((IDictionary<string, string>) this._dict);
    }

    private void addProperties(string[] lines)
    {
      char[] keyValueDelimiter = new char[1]{ '=' };
      foreach (string[] strArray in ((IEnumerable<string>) lines).Select<string, string[]>((Func<string, string[]>) (line => line.Split(keyValueDelimiter, 2))))
      {
        if (strArray.Length != 2)
          throw new InvalidKeyPropertiesException(strArray[0]);
        this[strArray[0]] = strArray[1];
      }
    }

    private static string[] getLinesWithProperties(string properties)
    {
      char[] separator = new char[1]{ '\n' };
      return ((IEnumerable<string>) properties.Split(separator, StringSplitOptions.RemoveEmptyEntries)).Select<string, string>((Func<string, string>) (line => line.TrimStart(' '))).Where<string>((Func<string, bool>) (line => !line.StartsWith("#", StringComparison.Ordinal))).ToArray<string>();
    }

    private static string[] mergeMultilineValues(string[] lines)
    {
      string currentProperty = string.Empty;
      return ((IEnumerable<string>) lines).Aggregate<string, List<string>>(new List<string>(), (Func<List<string>, string, List<string>>) ((acc, line) =>
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
      })).ToArray();
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
      if (!Properties.isInDoubleQuotes(str))
        return "\"" + str + "\"";
      return str;
    }

    private static string removeDoubleQuotes(string str)
    {
      if (!Properties.isInDoubleQuotes(str))
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
      return this._dict.Aggregate<KeyValuePair<string, string>, string>(string.Empty, (Func<string, KeyValuePair<string, string>, string>) ((properties, kv) =>
      {
        string[] array = ((IEnumerable<string>) Properties.escapedSpecialCharacters(kv.Value).ArrayFromCSV()).Select<string, string>((Func<string, string>) (value => value.PadLeft(kv.Key.Length + 3 + value.Length))).ToArray<string>();
        string str = string.Join(", \\\n", array).TrimStart();
        return properties + Properties.propertyPair(kv.Key, str, false) + (array.Length > 1 ? "\n\n" : "\n");
      }));
    }

    public string ToMinifiedString()
    {
      return this._dict.Aggregate<KeyValuePair<string, string>, string>(string.Empty, (Func<string, KeyValuePair<string, string>, string>) ((properties, kv) =>
      {
        string str = Properties.escapedSpecialCharacters(kv.Value);
        return properties + Properties.propertyPair(kv.Key, str, true) + "\n";
      }));
    }
  }
}