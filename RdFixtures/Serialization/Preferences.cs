using System;
using System.IO;

namespace Rd.Serialization
{
    public class Preferences
    {
        private bool _isDoubleQuoteMode;

        public Preferences(string propertiesPath, string userPropertiesPath)
        {
            this.propertiesPath = propertiesPath;
            this.userPropertiesPath = userPropertiesPath ?? defaultUserPropertiesPath;
            Reload();
        }

        protected Preferences(Properties properties, Properties userProperties)
        {
            this.properties = properties;
            this.userProperties = userProperties;
        }

        public static string defaultUserPropertiesPath => Environment.UserName + ".userproperties";

        public string propertiesPath { get; }

        public string userPropertiesPath { get; }

        public string[] keys => getMergedProperties().keys;

        public Properties properties { get; private set; }

        public Properties userProperties { get; private set; }

        public bool doubleQuoteMode
        {
            get => _isDoubleQuoteMode;
            set
            {
                _isDoubleQuoteMode = value;
                properties.doubleQuoteMode = value;
                userProperties.doubleQuoteMode = value;
            }
        }

        public bool minified { get; set; }

        public string this[string key]
        {
            get => getMergedProperties()[key];
            set
            {
                if (properties.HasKey(key) && !(value != this[key]))
                    return;
                properties[key] = value;
            }
        }

        public void Reload()
        {
            properties = loadProperties(propertiesPath);
            userProperties = loadProperties(userPropertiesPath);
        }

        public void Save()
        {
            File.WriteAllText(propertiesPath, minified ? properties.ToMinifiedString() : properties.ToString());
            File.WriteAllText(userPropertiesPath, minified ? userProperties.ToMinifiedString() : userProperties.ToString());
        }

        public bool HasKey(string key)
        {
            if (!properties.HasKey(key))
                return userProperties.HasKey(key);
            return true;
        }

        public void Reset(bool resetUser = false)
        {
            properties = new Properties();
            if (!resetUser)
                return;
            userProperties = new Properties();
        }

        public override string ToString()
        {
            return getMergedProperties().ToString();
        }

        private static Properties loadProperties(string path)
        {
            return new Properties(File.Exists(path) ? File.ReadAllText(path) : string.Empty);
        }

        private Properties getMergedProperties()
        {
            var properties = new Properties(this.properties.ToDictionary());
            properties.doubleQuoteMode = _isDoubleQuoteMode;
            properties.AddProperties(userProperties.ToDictionary(), true);
            return properties;
        }
    }
}