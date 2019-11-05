using System;
using System.Collections.Generic;
using System.Linq;
using DesperateDevs.Serialization;
using Entitas.CodeGeneration.Attributes;

namespace Entitas.CodeGeneration.Plugins
{
    public class ContextsComponentDataProvider : IComponentDataProvider, IConfigurable
    {
        private readonly ContextNamesConfig _contextNamesConfig = new ContextNamesConfig();

        public void Provide(Type type, ComponentData data)
        {
            var contextNames = GetContextNamesOrDefault(type);
            data.SetContextNames(contextNames);
        }

        public Dictionary<string, string> defaultProperties => _contextNamesConfig.defaultProperties;

        public void Configure(Preferences preferences)
        {
            _contextNamesConfig.Configure(preferences);
        }

        public string[] GetContextNames(Type type)
        {
            return Attribute
                .GetCustomAttributes(type)
                .OfType<ContextAttribute>()
                .Select(attr => attr.contextName)
                .ToArray();
        }

        public string[] GetContextNamesOrDefault(Type type)
        {
            var contextNames = GetContextNames(type);
            if (contextNames.Length == 0) contextNames = new[] {_contextNamesConfig.contextNames[0]};

            return contextNames;
        }
    }
}