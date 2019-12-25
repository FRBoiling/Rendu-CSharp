using System;
using System.Linq;

namespace Rd.Plugins
{
    public class IsUniqueComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            //var isUnique = Attribute
            //    .GetCustomAttributes(type)
            //    .OfType<UniqueAttribute>()
            //    .Any();

            //var attr11 = Attribute.GetCustomAttributes(type);
            ////foreach (var attr in attr11)
            ////{
            ////    var name = attr.GetType().Name;
            ////}
            //var attrs = attr11.Where(attr => attr.GetType().Name == "UniqueAttribute");
            //var isUnique = attrs.Any();

            var isUnique = Attribute
                .GetCustomAttributes(type)
                .Where(attr => attr.GetType().Name == "UniqueAttribute")
                .Any();

            data.IsUnique(isUnique);
        }
    }
}