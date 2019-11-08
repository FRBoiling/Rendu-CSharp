using System;
using Rd.Utils;

namespace Rd.Plugins.Component.DataProviders.ComponentDataProviders
{
    public class ComponentTypeComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            data.SetTypeName(type.ToCompilableString());
        }
    }
}