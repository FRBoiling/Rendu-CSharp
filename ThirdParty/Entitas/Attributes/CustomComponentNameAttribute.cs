using System;

namespace Entitas.Attributes
{
    [Obsolete("Use [ComponentName] instead", false)]
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class CustomComponentNameAttribute : Attribute
    {
        public readonly string[] componentNames;

        public CustomComponentNameAttribute(params string[] componentNames)
        {
            this.componentNames = componentNames;
        }
    }
}