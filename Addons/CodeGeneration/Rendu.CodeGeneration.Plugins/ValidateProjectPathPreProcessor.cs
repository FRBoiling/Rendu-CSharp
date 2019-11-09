using System;
using System.Collections.Generic;
using System.IO;
using Rd.CodeGeneration;
using Rd.Serialization;

namespace Rendu.CodeGeneration.Plugins
{
    public class ValidateProjectPathPreProcessor : IPreProcessor, IConfigurable
    {
        private readonly ProjectPathConfig _projectPathConfig = new ProjectPathConfig();
        private Preferences _preferences;

        public string name
        {
            get
            {
                return "Validate Project Path";
            }
        }

        public int priority
        {
            get
            {
                return -10;
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
            this._preferences = preferences;
            this._projectPathConfig.Configure(preferences);
        }

        public void PreProcess()
        {
            if (!File.Exists(this._projectPathConfig.projectPath))
                throw new Exception("Could not find file '" + this._projectPathConfig.projectPath + "'\nPress \"Assets -> Open C# Project\" to create the project and make sure that \"Project Path\" is set to the created *.csproj.");
        }
    }
}