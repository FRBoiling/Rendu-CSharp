using System.Collections.Generic;
using Rd.Serialization;

namespace Rd.Plugins.Configs
{
    public class IgnoreNamespacesConfig : AbstractConfigurableConfig
    {
        private const string IGNORE_NAMESPACES_KEY = "Entitas.Rd.CodeGeneration.Rd.Plugins.IgnoreNamespaces";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {IGNORE_NAMESPACES_KEY, "false"}
            };

        public bool ignoreNamespaces
        {
            get => _preferences[IGNORE_NAMESPACES_KEY] == "true";
            set => _preferences[IGNORE_NAMESPACES_KEY] = value.ToString();
        }
    }
}