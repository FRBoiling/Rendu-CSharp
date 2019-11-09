using System;

namespace Entitas.Attributes.EntityIndex
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class)]
    public class PrimaryEntityIndexAttribute : AbstractEntityIndexAttribute
    {
        public PrimaryEntityIndexAttribute() : base(EntityIndexType.PrimaryEntityIndex)
        {
        }
    }
}