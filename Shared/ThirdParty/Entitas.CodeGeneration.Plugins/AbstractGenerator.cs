using System.Collections.Generic;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Serialization;

namespace Entitas.CodeGeneration.Plugins
{
    public abstract class AbstractGenerator : ICodeGenerator, IConfigurable
    {
        private readonly IgnoreNamespacesConfig _ignoreNamespacesConfig = new IgnoreNamespacesConfig();

        public abstract string name { get; }
        public int priority => 0;
        public bool runInDryMode => true;

        public abstract CodeGenFile[] Generate(CodeGeneratorData[] data);

        public Dictionary<string, string> defaultProperties => _ignoreNamespacesConfig.defaultProperties;

        public void Configure(Preferences preferences)
        {
            _ignoreNamespacesConfig.Configure(preferences);
            CodeGeneratorExtentions.ignoreNamespaces = _ignoreNamespacesConfig.ignoreNamespaces;
        }
    }
}