using DesperateDevs.Serialization;
using System.Collections.Generic;

namespace DesperateDevs.CodeGeneration.Plugins
{
    public class ProjectPathConfig : AbstractConfigurableConfig
    {
        private const string PROJECT_PATH_KEY = "DesperateDevs.CodeGeneration.Plugins.ProjectPath";

        public override Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "DesperateDevs.CodeGeneration.Plugins.ProjectPath",
                        "Assembly-CSharp.csproj"
                    }
                };
            }
        }

        public string projectPath
        {
            get
            {
                return this._preferences["DesperateDevs.CodeGeneration.Plugins.ProjectPath"];
            }
        }
    }
}