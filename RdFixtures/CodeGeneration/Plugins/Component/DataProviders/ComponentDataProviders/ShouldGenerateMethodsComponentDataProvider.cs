using System;
using System.Linq;
using Entitas.Attributes;

namespace Rd.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class ShouldGenerateMethodsComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var generate = !Attribute
                .GetCustomAttributes(type)
                .OfType<DontGenerateAttribute>()
                .Any();

            data.ShouldGenerateMethods(generate);
        }
    }
}