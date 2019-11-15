using System.Collections.Generic;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class TargetDirectoryConfig : AbstractConfigurableConfig
    {
        private const string TARGET_DIRECTORY_KEY = "Rendu.CodeGeneration.Plugins.TargetDirectory";

        public override Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "Rendu.CodeGeneration.Plugins.TargetDirectory",
                        "Assets"
                    }
                };
            }
        }

        public string targetDirectory
        {
            get
            {
                return this._preferences["Rendu.CodeGeneration.Plugins.TargetDirectory"].ToSafeDirectory();
            }
        }
    }
}