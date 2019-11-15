
using Entitas.Entity;

namespace Entitas.Group
{
    public delegate void GroupUpdated<TEntity>(
        IGroup<TEntity> group, TEntity entity, int index,
        IComponent previousComponent, IComponent newComponent
    ) where TEntity : class, IEntity;
}