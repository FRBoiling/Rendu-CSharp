using System.Collections.Generic;

namespace Entitas.CodeGeneration.Plugins.Configs
{
    public class TemplatesConfig : AbstractConfigurableConfig
    {
        private const string TEMPLATES_KEY = "Entitas.Rd.CodeGeneration.Entitas.Plugins.Templates";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {TEMPLATES_KEY, "Entitas.Plugins/Entitas/Templates"}
            };

        public string[] templates
        {
            get => _preferences[TEMPLATES_KEY].ArrayFromCSV();
            set => _preferences[TEMPLATES_KEY] = value.ToCSV();
        }
    }
}