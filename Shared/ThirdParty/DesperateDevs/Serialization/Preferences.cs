using System;
using System.IO;

namespace DesperateDevs.Serialization
{
  public class Preferences
  {
    private readonly string _propertiesPath;
    private readonly string _userPropertiesPath;
    private Properties _properties;
    private Properties _userProperties;
    private bool _isDoubleQuoteMode;
    private bool _isMinified;

    public static string defaultUserPropertiesPath
    {
      get
      {
        return Environment.UserName + ".userproperties";
      }
    }

    public string propertiesPath
    {
      get
      {
        return this._propertiesPath;
      }
    }

    public string userPropertiesPath
    {
      get
      {
        return this._userPropertiesPath;
      }
    }

    public string[] keys
    {
      get
      {
        return this.getMergedProperties().keys;
      }
    }

    public Properties properties
    {
      get
      {
        return this._properties;
      }
    }

    public Properties userProperties
    {
      get
      {
        return this._userProperties;
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
        this._properties.doubleQuoteMode = value;
        this._userProperties.doubleQuoteMode = value;
      }
    }

    public bool minified
    {
      get
      {
        return this._isMinified;
      }
      set
      {
        this._isMinified = value;
      }
    }

    public Preferences(string propertiesPath, string userPropertiesPath)
    {
      this._propertiesPath = propertiesPath;
      this._userPropertiesPath = userPropertiesPath ?? Preferences.defaultUserPropertiesPath;
      this.Reload();
    }

    protected Preferences(Properties properties, Properties userProperties)
    {
      this._properties = properties;
      this._userProperties = userProperties;
    }

    public void Reload()
    {
      this._properties = Preferences.loadProperties(this._propertiesPath);
      this._userProperties = Preferences.loadProperties(this._userPropertiesPath);
    }

    public void Save()
    {
      File.WriteAllText(this._propertiesPath, this._isMinified ? this._properties.ToMinifiedString() : this._properties.ToString());
      File.WriteAllText(this._userPropertiesPath, this._isMinified ? this._userProperties.ToMinifiedString() : this._userProperties.ToString());
    }

    public string this[string key]
    {
      get
      {
        return this.getMergedProperties()[key];
      }
      set
      {
        if (this._properties.HasKey(key) && !(value != this[key]))
          return;
        this._properties[key] = value;
      }
    }

    public bool HasKey(string key)
    {
      if (!this._properties.HasKey(key))
        return this._userProperties.HasKey(key);
      return true;
    }

    public void Reset(bool resetUser = false)
    {
      this._properties = new Properties();
      if (!resetUser)
        return;
      this._userProperties = new Properties();
    }

    public override string ToString()
    {
      return this.getMergedProperties().ToString();
    }

    private static Properties loadProperties(string path)
    {
      return new Properties(File.Exists(path) ? File.ReadAllText(path) : string.Empty);
    }

    private Properties getMergedProperties()
    {
      Properties properties = new Properties(this._properties.ToDictionary());
      properties.doubleQuoteMode = this._isDoubleQuoteMode;
      properties.AddProperties(this._userProperties.ToDictionary(), true);
      return properties;
    }
  }
}