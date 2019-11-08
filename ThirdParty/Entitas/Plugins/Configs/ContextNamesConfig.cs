using System.Collections.Generic;

namespace Entitas.CodeGeneration.Plugins.Configs
{
    public class ContextNamesConfig : AbstractConfigurableConfig
    {
        private const string CONTEXTS_KEY = "Entitas.Rd.CodeGeneration.Plugins.Contexts";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {CONTEXTS_KEY, "Game, Input"}
            };

        public string[] contextNames
        {
            get => _preferences[CONTEXTS_KEY].ArrayFromCSV();
            set => _preferences[CONTEXTS_KEY] = value.ToCSV();
        }
    }
}