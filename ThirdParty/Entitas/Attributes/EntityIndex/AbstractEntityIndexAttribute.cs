using System;

namespace Entitas.Attributes.EntityIndex
{
    public abstract class AbstractEntityIndexAttribute : Attribute
    {
        public readonly EntityIndexType entityIndexType;

        protected AbstractEntityIndexAttribute(EntityIndexType entityIndexType)
        {
            this.entityIndexType = entityIndexType;
        }
    }
}