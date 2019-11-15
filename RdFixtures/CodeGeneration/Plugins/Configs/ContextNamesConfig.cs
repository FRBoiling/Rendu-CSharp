using System.Collections.Generic;
using Rd.Serialization;
using Rd.Utils;

namespace Rd.Plugins.Configs
{
    public class ContextNamesConfig : AbstractConfigurableConfig
    {
        private const string CONTEXTS_KEY = "Rendu.CodeGeneration.Plugins.Contexts";

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