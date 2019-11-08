using System.Collections.Generic;

namespace Entitas.CodeGeneration.Plugins.Configs
{
    public class AssembliesConfig : AbstractConfigurableConfig
    {
        private const string ASSEMBLIES_KEY = "Entitas.Rd.CodeGeneration.Entitas.Plugins.Assemblies";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {ASSEMBLIES_KEY, "Library/ScriptAssemblies/Assembly-CSharp.dll"}
            };

        public string[] assemblies
        {
            get => _preferences[ASSEMBLIES_KEY].ArrayFromCSV();
            set => _preferences[ASSEMBLIES_KEY] = value.ToCSV();
        }
    }
}