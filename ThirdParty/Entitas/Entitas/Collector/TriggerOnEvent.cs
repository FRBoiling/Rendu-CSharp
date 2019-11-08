using Entitas.Entity;
using Entitas.Group;
using Entitas.Matcher.Interfaces;

namespace Entitas.Collector
{
    public struct TriggerOnEvent<TEntity> where TEntity : class, IEntity
    {
        public readonly IMatcher<TEntity> matcher;
        public readonly GroupEvent groupEvent;

        public TriggerOnEvent(IMatcher<TEntity> matcher, GroupEvent groupEvent)
        {
            this.matcher = matcher;
            this.groupEvent = groupEvent;
        }
    }
}