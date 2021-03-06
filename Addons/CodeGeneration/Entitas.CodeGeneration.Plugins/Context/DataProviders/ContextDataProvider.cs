using System.Collections.Generic;
using System.Linq;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Serialization;

namespace Entitas.CodeGeneration.Plugins
{
    public class ContextDataProvider : IDataProvider, IConfigurable
    {
        private readonly ContextNamesConfig _contextNamesConfig = new ContextNamesConfig();

        public Dictionary<string, string> defaultProperties => _contextNamesConfig.defaultProperties;

        public void Configure(Preferences preferences)
        {
            _contextNamesConfig.Configure(preferences);
        }

        public string name => "Context";
        public int priority => 0;
        public bool runInDryMode => true;

        public CodeGeneratorData[] GetData()
        {
            return _contextNamesConfig.contextNames
                .Select(contextName =>
                {
                    var data = new ContextData();
                    data.SetContextName(contextName);
                    return data;
                }).ToArray();
        }
    }
}