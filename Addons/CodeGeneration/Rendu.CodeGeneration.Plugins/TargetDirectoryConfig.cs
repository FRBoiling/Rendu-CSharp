using System.Collections.Generic;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class TargetDirectoryConfig : AbstractConfigurableConfig
    {
        private const string TARGET_DIRECTORY_KEY = "Rd.CodeGeneration.Rd.Plugins.TargetDirectory";

        public override Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "Rd.CodeGeneration.Rd.Plugins.TargetDirectory",
                        "Assets"
                    }
                };
            }
        }

        public string targetDirectory
        {
            get
            {
                return this._preferences["Rd.CodeGeneration.Rd.Plugins.TargetDirectory"].ToSafeDirectory();
            }
        }
    }
}