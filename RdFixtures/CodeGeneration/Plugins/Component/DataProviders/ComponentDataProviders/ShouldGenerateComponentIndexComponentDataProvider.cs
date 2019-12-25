using System;
using System.Collections.Generic;
using Entitas.Attributes;

namespace Rd.Plugins
{
    public class ShouldGenerateComponentIndexComponentDataProvider : IComponentDataProvider
    {
        public void Provide(Type type, ComponentData data)
        {
            data.ShouldGenerateIndex(getGenerateIndex(type));
        }

        private bool getGenerateIndex(Type type)
        {
            //var attr = Attribute
            //    .GetCustomAttributes(type)
            //    .OfType<DontGenerateAttribute>()
            //    .SingleOrDefault();

            //return attr == null || attr.generateIndex;


            var indexList = new List<bool>();
            var attributesData = type.GetCustomAttributesData();
            foreach (var attribute in attributesData)
            {
                if (attribute.AttributeType.Name != typeof(DontGenerateAttribute).Name)
                {
                    continue;
                }
                foreach (var item in attribute.ConstructorArguments)
                {
                    bool index = (bool)item.Value ;
                    if (!indexList.Contains(index)) indexList.Add(index);
                }
                if (indexList.Count ==0)
                {
                    indexList.Add(true);
                }
            }
            if (indexList.Count == 0)
            {
                return true;
            }
            else
            {
                return !indexList[0];
            }
        }
    }
}