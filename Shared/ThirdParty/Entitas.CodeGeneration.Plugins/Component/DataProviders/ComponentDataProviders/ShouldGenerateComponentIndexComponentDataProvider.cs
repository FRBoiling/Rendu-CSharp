using System;
using System.Linq;
using Entitas.CodeGeneration.Attributes;

namespace Entitas.CodeGeneration.Plugins
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