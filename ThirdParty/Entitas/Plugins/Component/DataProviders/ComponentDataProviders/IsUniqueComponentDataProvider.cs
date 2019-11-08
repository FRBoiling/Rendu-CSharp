using System;
using Entitas.CodeGeneration.Attributes;

namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class IsUniqueComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var isUnique = Attribute
                .GetCustomAttributes(type)
                .OfType<UniqueAttribute>()
                .Any();

            data.IsUnique(isUnique);
        }
    }
}