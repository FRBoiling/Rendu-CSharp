using System.Collections.Generic;

namespace Rd.Serialization
{
    public abstract class AbstractConfigurableConfig : IConfigurable
    {
        protected Preferences _preferences;

        public abstract Dictionary<string, string> defaultProperties { get; }

        public virtual void Configure(Preferences preferences)
        {
            _preferences = preferences;
        }

        public override string ToString()
        {
            return _preferences.ToString();
        }
    }
}