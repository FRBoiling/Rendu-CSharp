using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Rd.CodeGeneration;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class TargetFrameworkProfilePreProcessor : IPreProcessor, IConfigurable
    {
        private readonly ProjectPathConfig _projectPathConfig = new ProjectPathConfig();

        public string name
        {
            get
            {
                return "Fix Target Framework Profile";
            }
        }

        public int priority
        {
            get
            {
                return 0;
            }
        }

        public bool runInDryMode
        {
            get
            {
                return true;
            }
        }

        public Dictionary<string, string> defaultProperties
        {
            get
            {
                return this._projectPathConfig.defaultProperties;
            }
        }

        public void Configure(Preferences preferences)
        {
            this._projectPathConfig.Configure(preferences);
        }

        public void PreProcess()
        {
            File.WriteAllText(this._projectPathConfig.projectPath, this.removeTargetFrameworkProfile(File.ReadAllText(this._projectPathConfig.projectPath)));
        }

        private string removeTargetFrameworkProfile(string project)
        {
            project = Regex.Replace(project, "\\s*<TargetFrameworkProfile>Unity Subset v3.5</TargetFrameworkProfile>", string.Empty);
            project = Regex.Replace(project, "\\s*<TargetFrameworkProfile>Unity Full v3.5</TargetFrameworkProfile>", string.Empty);
            return project;
        }
    }
}