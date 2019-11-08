using Entitas.Collector;
using Entitas.Entity;

namespace Entitas.Group
{
    public static class GroupExtension
    {
        /// Creates a Collector for this group.
        public static ICollector<TEntity> CreateCollector<TEntity>(this IGroup<TEntity> group, GroupEvent groupEvent = GroupEvent.Added) where TEntity : class, IEntity
        {
            return new Collector<TEntity>(group, groupEvent);
        }
    }
}