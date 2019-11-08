using System;

namespace Entitas.CodeGeneration.Attributes.EntityIndex
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class)]
    public class EntityIndexAttribute : AbstractEntityIndexAttribute
    {
        public EntityIndexAttribute() : base(EntityIndexType.EntityIndex)
        {
        }
    }
}