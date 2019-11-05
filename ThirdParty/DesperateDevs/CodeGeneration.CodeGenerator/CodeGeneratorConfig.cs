using System.Collections.Generic;
using DesperateDevs.Serialization;
using DesperateDevs.Utils;

namespace DesperateDevs.CodeGeneration.CodeGenerator
{
    public class CodeGeneratorConfig : AbstractConfigurableConfig
    {
        public const string SEARCH_PATHS_KEY = "Jenny.SearchPaths";
        public const string PLUGINS_PATHS_KEY = "Jenny.Plugins";
        public const string PRE_PROCESSORS_KEY = "Jenny.PreProcessors";
        public const string DATA_PROVIDERS_KEY = "Jenny.DataProviders";
        public const string CODE_GENERATORS_KEY = "Jenny.CodeGenerators";
        public const string POST_PROCESSORS_KEY = "Jenny.PostProcessors";
        public const string PORT_KEY = "Jenny.Server.Port";
        public const string HOST_KEY = "Jenny.Client.Host";

        public override Dictionary<string, string> defaultProperties =>
            new Dictionary<string, string>
            {
                {
                    "Jenny.SearchPaths",
                    string.Empty
                },
                {
                    "Jenny.Plugins",
                    string.Empty
                },
                {
                    "Jenny.PreProcessors",
                    string.Empty
                },
                {
                    "Jenny.DataProviders",
                    string.Empty
                },
                {
                    "Jenny.CodeGenerators",
                    string.Empty
                },
                {
                    "Jenny.PostProcessors",
                    string.Empty
                },
                {
                    "Jenny.Server.Port",
                    "3333"
                },
                {
                    "Jenny.Client.Host",
                    "localhost"
                }
            };

        public string[] searchPaths
        {
            get => _preferences["Jenny.SearchPaths"].ArrayFromCSV();
            set => _preferences["Jenny.SearchPaths"] = value.ToCSV();
        }

        public string[] plugins
        {
            get => _preferences["Jenny.Plugins"].ArrayFromCSV();
            set => _preferences["Jenny.Plugins"] = value.ToCSV();
        }

        public string[] preProcessors
        {
            get => _preferences["Jenny.PreProcessors"].ArrayFromCSV();
            set => _preferences["Jenny.PreProcessors"] = value.ToCSV();
        }

        public string[] dataProviders
        {
            get => _preferences["Jenny.DataProviders"].ArrayFromCSV();
            set => _preferences["Jenny.DataProviders"] = value.ToCSV();
        }

        public string[] codeGenerators
        {
            get => _preferences["Jenny.CodeGenerators"].ArrayFromCSV();
            set => _preferences["Jenny.CodeGenerators"] = value.ToCSV();
        }

        public string[] postProcessors
        {
            get => _preferences["Jenny.PostProcessors"].ArrayFromCSV();
            set => _preferences["Jenny.PostProcessors"] = value.ToCSV();
        }

        public int port
        {
            get => int.Parse(_preferences["Jenny.Server.Port"]);
            set => _preferences["Jenny.Server.Port"] = value.ToString();
        }

        public string host
        {
            get => _preferences["Jenny.Client.Host"];
            set => _preferences["Jenny.Client.Host"] = value;
        }
    }
}