using System;

namespace Entitas.CodeGeneration.Attributes.EntityIndex
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