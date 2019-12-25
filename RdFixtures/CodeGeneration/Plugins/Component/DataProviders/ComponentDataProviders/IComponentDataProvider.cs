using System;

namespace Rd.Plugins
{
    public interface IComponentDataProvider
    {
        void Provide(Type type, ComponentData data);
    }
}