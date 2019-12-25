using System;
using System.ComponentModel;
using Rd.Utils;

namespace Rd.Plugins
{
    public class ShouldGenerateComponentComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            //var shouldGenerateComponent = type.ImplementsInterface<IComponent>();
            var shouldGenerateComponent = type.ImplementsInterface(typeof(IComponent).Name);
            data.ShouldGenerateComponent(shouldGenerateComponent);
            if (shouldGenerateComponent) data.SetObjectTypeName(type.ToCompilableString());
        }
    }
}