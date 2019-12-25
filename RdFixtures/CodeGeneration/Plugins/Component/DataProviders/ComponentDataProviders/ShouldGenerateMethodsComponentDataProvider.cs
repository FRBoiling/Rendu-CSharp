using System;
using System.Linq;

namespace Rd.Plugins
{
    public class ShouldGenerateMethodsComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            var generate = !Attribute
                .GetCustomAttributes(type)
                //.OfType<DontGenerateAttribute>()
                .Where(attr=>attr.GetType().Name == "DontGenerateAttribute")
                .Any();

            data.ShouldGenerateMethods(generate);
        }
    }
}