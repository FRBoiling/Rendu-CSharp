using System;
using System.Collections.Generic;
using Entitas.Attributes;

namespace Rd.Plugins
{
    public class FlagPrefixComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            data.SetFlagPrefix(getFlagPrefix(type));
        }

        private string getFlagPrefix(Type type)
        {
            //var attr = Attribute.GetCustomAttributes(type)
            //    .OfType<FlagPrefixAttribute>()
            //    .SingleOrDefault();
            //return attribute == null ? "is" : attribute.prefix;

            //var attribute = Attribute
            //    .GetCustomAttributes(type)
            //    .Where(attr => attr.GetType().Name == "FlagPrefixAttribute")
            //    .SingleOrDefault();

            var flagPrefixList = new List<string>();
            var attributesData = type.GetCustomAttributesData();
            foreach (var attribute in attributesData)
            {
                if (attribute.AttributeType.Name != typeof(FlagPrefixAttribute).Name)
                {
                    continue;
                }
                foreach (var item in attribute.ConstructorArguments)
                {
                    var prefixName = item.Value as string;
                    if (prefixName == null)
                    {
                        continue;
                    }
                    if (!flagPrefixList.Contains(prefixName)) flagPrefixList.Add(prefixName);
                }
            }
            return flagPrefixList.Count == 0 ? "is" : flagPrefixList[0];
        }
    }
}