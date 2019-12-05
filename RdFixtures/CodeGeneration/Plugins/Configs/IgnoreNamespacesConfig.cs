using System.Collections.Generic;
using Rd.Serialization;

namespace Rd.Plugins.Configs
{
    public class IgnoreNamespacesConfig : AbstractConfigurableConfig
    {
        private const string IGNORE_NAMESPACES_KEY = "Rendu.CodeGeneration.Plugins.IgnoreNamespaces";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {IGNORE_NAMESPACES_KEY, "true"}
            };

        public bool ignoreNamespaces
        {
            get => _preferences[IGNORE_NAMESPACES_KEY] == "true";
            set => _preferences[IGNORE_NAMESPACES_KEY] = value.ToString();
        }
    }
}