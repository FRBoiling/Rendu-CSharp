using System.Collections.Generic;
using Entitas.Entity;

namespace Entitas.Collector
{
    public interface ICollector
    {
        int count { get; }

        void Activate();
        void Deactivate();
        void ClearCollectedEntities();

        IEnumerable<TCast> GetCollectedEntities<TCast>() where TCast : class, IEntity;
    }

    public interface ICollector<TEntity> : ICollector where TEntity : class, IEntity
    {
        HashSet<TEntity> collectedEntities { get; }
    }
}