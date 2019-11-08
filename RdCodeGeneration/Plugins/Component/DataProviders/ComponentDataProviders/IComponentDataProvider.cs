using System;

namespace Entitas.CodeGeneration.Plugins.Component.DataProviders.ComponentDataProviders
{
    public interface IComponentDataProvider
    {
        void Provide(Type type, ComponentData data);
    }
}