using System;
using System.Collections.Generic;
using Entitas.Attributes;
using Rd.Serialization;

namespace Rd.Plugins
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
            //return Attribute
            //    .GetCustomAttributes(type)
            //    .OfType<ContextAttribute>()
            //    .Select(attr => attr.contextName)
            //    .ToArray();


            var contextNameList = new List<string>();
            var attributesData = type.GetCustomAttributesData();
            foreach (var attribute in attributesData)
            {
                if (attribute.AttributeType.Name != typeof(ContextAttribute).Name)
                {
                    continue;
                }
                foreach (var item in attribute.ConstructorArguments)
                {
                    var contextName = item.Value as string;
                    if (contextName == null)
                    {
                        continue;
                    }
                    if (!contextNameList.Contains(contextName)) contextNameList.Add(contextName);
                }
            }
            return contextNameList.ToArray();
        }

        public string[] GetContextNamesOrDefault(Type type)
        {
            var contextNames = GetContextNames(type);
            if (contextNames.Length == 0) contextNames = new[] { _contextNamesConfig.contextNames[0] };

            return contextNames;
        }
    }
}