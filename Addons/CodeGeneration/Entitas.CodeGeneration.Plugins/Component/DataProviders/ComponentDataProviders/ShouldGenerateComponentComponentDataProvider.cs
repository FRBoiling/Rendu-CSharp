using System;
using DesperateDevs.Utils;

namespace Entitas.CodeGeneration.Plugins
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