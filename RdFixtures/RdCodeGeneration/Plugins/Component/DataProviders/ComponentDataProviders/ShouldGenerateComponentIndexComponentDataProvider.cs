using System;
using System.Linq;
using Entitas.Attributes;

namespace Rd.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class ShouldGenerateComponentIndexComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            data.ShouldGenerateIndex(getGenerateIndex(type));
        }

        private bool getGenerateIndex(Type type)
        {
            var attr = Attribute
                .GetCustomAttributes(type)
                .OfType<DontGenerateAttribute>()
                .SingleOrDefault();

            return attr == null || attr.generateIndex;
        }
    }
}