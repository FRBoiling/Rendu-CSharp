using System;

namespace Entitas.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = true)]
    public class ContextAttribute : Attribute
    {
        public readonly string contextName;

        public ContextAttribute(string contextName)
        {
            this.contextName = contextName;
        }
    }
}