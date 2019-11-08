using System;

namespace Rd.Plugins.Component.DataProviders.ComponentDataProviders
{
    public interface IComponentDataProvider
    {
        void Provide(Type type, ComponentData data);
    }
}