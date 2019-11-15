using System.Collections.Generic;
using Rd.Serialization;
using Rd.Utils;

namespace Rd.Plugins.Configs
{
    public class TemplatesConfig : AbstractConfigurableConfig
    {
        private const string TEMPLATES_KEY = "Entitas.Rendu.CodeGeneration.Plugins.Templates";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {TEMPLATES_KEY, "Rd.Plugins/Entitas/Templates"}
            };

        public string[] templates
        {
            get => _preferences[TEMPLATES_KEY].ArrayFromCSV();
            set => _preferences[TEMPLATES_KEY] = value.ToCSV();
        }
    }
}