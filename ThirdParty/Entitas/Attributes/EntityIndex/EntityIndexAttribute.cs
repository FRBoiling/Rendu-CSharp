using System;

namespace Entitas.Attributes.EntityIndex
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class)]
    public class EntityIndexAttribute : AbstractEntityIndexAttribute
    {
        public EntityIndexAttribute() : base(EntityIndexType.EntityIndex)
        {
        }
    }
}