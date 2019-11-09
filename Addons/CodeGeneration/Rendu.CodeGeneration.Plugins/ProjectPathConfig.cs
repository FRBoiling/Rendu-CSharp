using System.Collections.Generic;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class ProjectPathConfig : AbstractConfigurableConfig
    {
        private const string PROJECT_PATH_KEY = "Rd.CodeGeneration.Rd.Plugins.ProjectPath";

        public override Dictionary<string, string> defaultProperties
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {
                        "Rd.CodeGeneration.Rd.Plugins.ProjectPath",
                        "Assembly-CSharp.csproj"
                    }
                };
            }
        }

        public string projectPath
        {
            get
            {
                return this._preferences["Rd.CodeGeneration.Rd.Plugins.ProjectPath"];
            }
        }
    }
}