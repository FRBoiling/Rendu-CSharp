using System;
using Entitas.CodeGeneration.Attributes;

namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class FlagPrefixComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            data.SetFlagPrefix(getFlagPrefix(type));
        }

        private string getFlagPrefix(Type type)
        {
            var attr = Attribute.GetCustomAttributes(type)
                .OfType<FlagPrefixAttribute>()
                .SingleOrDefault();

            return attr == null ? "is" : attr.prefix;
        }
    }
}