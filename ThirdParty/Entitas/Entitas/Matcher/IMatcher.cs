using Entitas.Entity;

namespace Entitas.Matcher
{
    public interface IMatcher<TEntity> where TEntity : class, IEntity
    {
        int[] indices { get; }
        bool Matches(TEntity entity);
    }
}