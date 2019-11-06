using DesperateDevs.Serialization;
using System.Collections.Generic;

namespace DesperateDevs.CodeGeneration.Plugins
{
    public class TargetDirectoryConfig : AbstractConfigurableConfig
    {
        private const string TARGET_DIRECTORY_KEY = "DesperateDevs.CodeGeneration.Plugins.TargetDirectory";

        public override Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "DesperateDevs.CodeGeneration.Plugins.TargetDirectory",
                        "Assets"
                    }
                };
            }
        }

        public string targetDirectory
        {
            get
            {
                return this._preferences["DesperateDevs.CodeGeneration.Plugins.TargetDirectory"].ToSafeDirectory();
            }
        }
    }
}