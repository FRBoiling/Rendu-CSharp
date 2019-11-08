using Entitas.Entity;

namespace Entitas.Matcher.Interfaces
{
    public interface INoneOfMatcher<TEntity> : ICompoundMatcher<TEntity> where TEntity : class, IEntity
    {
    }
}