using Entitas.Entity;

namespace Entitas.Matcher
{
    public interface IAllOfMatcher<TEntity> : IAnyOfMatcher<TEntity> where TEntity : class, IEntity
    {
        IAnyOfMatcher<TEntity> AnyOf(params int[] indices);
        IAnyOfMatcher<TEntity> AnyOf(params IMatcher<TEntity>[] matchers);
    }
}