using System.Collections.Generic;
using Entitas.Entity;
using Entitas;
using Entitas.Group;
using Entitas.Matcher;

namespace Entitas.Context
{
    public interface IContext
    {
        int totalComponents { get; }

        Stack<IComponent>[] componentPools { get; }
        ContextInfo contextInfo { get; }

        int count { get; }
        int reusableEntitiesCount { get; }
        int retainedEntitiesCount { get; }

        event ContextEntityChanged OnEntityCreated;
        event ContextEntityChanged OnEntityWillBeDestroyed;
        event ContextEntityChanged OnEntityDestroyed;

        event ContextGroupChanged OnGroupCreated;

        void DestroyAllEntities();

        void AddEntityIndex(IEntityIndex entityIndex);
        IEntityIndex GetEntityIndex(string name);

        void ResetCreationIndex();
        void ClearComponentPool(int index);
        void ClearComponentPools();
        void RemoveAllEventHandlers();
        void Reset();
    }

    public interface IContext<TEntity> : IContext where TEntity : class, IEntity
    {
        TEntity CreateEntity();

        bool HasEntity(TEntity entity);
        TEntity[] GetEntities();

        IGroup<TEntity> GetGroup(IMatcher<TEntity> matcher);
    }
}