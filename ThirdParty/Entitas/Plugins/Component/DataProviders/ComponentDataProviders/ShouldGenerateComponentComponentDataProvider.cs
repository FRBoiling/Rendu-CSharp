using System;

namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class ShouldGenerateComponentComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var shouldGenerateComponent = !type.ImplementsInterface<IComponent>();
            data.ShouldGenerateComponent(shouldGenerateComponent);
            if (shouldGenerateComponent) data.SetObjectTypeName(type.ToCompilableString());
        }
    }
}