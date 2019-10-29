using System.Collections.Generic;

namespace DesperateDevs.Serialization
{
    public abstract class AbstractConfigurableConfig : IConfigurable
    {
        protected Preferences _preferences;

        public abstract Dictionary<string, string> defaultProperties { get; }

        public virtual void Configure(Preferences preferences)
        {
            this._preferences = preferences;
        }

        public override string ToString()
        {
            return this._preferences.ToString();
        }
    }
}