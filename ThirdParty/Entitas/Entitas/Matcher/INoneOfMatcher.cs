using Entitas.Entity;

namespace Entitas.Matcher
{
    public interface INoneOfMatcher<TEntity> : ICompoundMatcher<TEntity> where TEntity : class, IEntity
    {
    }
}