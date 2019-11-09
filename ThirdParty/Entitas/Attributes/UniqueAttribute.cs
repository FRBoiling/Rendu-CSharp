using System;

namespace Entitas.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
    public class UniqueAttribute : Attribute
    {
    }
}