namespace Entitas
{
    public partial class Matcher<TEntity> : IAllOfMatcher<TEntity> where TEntity : class, IEntity
    {
        private int[] _indices;

        private Matcher()
        {
        }

        public string[] componentNames { get; set; }

        public int[] indices
        {
            get
            {
                if (_indices == null) _indices = mergeIndices(allOfIndices, anyOfIndices, noneOfIndices);
                return _indices;
            }
        }

        public int[] allOfIndices { get; private set; }

        public int[] anyOfIndices { get; private set; }

        public int[] noneOfIndices { get; private set; }

        IAnyOfMatcher<TEntity> IAllOfMatcher<TEntity>.AnyOf(params int[] indices)
        {
            anyOfIndices = distinctIndices(indices);
            _indices = null;
            _isHashCached = false;
            return this;
        }

        IAnyOfMatcher<TEntity> IAllOfMatcher<TEntity>.AnyOf(params IMatcher<TEntity>[] matchers)
        {
            return ((IAllOfMatcher<TEntity>) this).AnyOf(mergeIndices(matchers));
        }

        public INoneOfMatcher<TEntity> NoneOf(params int[] indices)
        {
            noneOfIndices = distinctIndices(indices);
            _indices = null;
            _isHashCached = false;
            return this;
        }

        public INoneOfMatcher<TEntity> NoneOf(params IMatcher<TEntity>[] matchers)
        {
            return NoneOf(mergeIndices(matchers));
        }

        public bool Matches(TEntity entity)
        {
            return (allOfIndices == null || entity.HasComponents(allOfIndices))
                   && (anyOfIndices == null || entity.HasAnyComponent(anyOfIndices))
                   && (noneOfIndices == null || !entity.HasAnyComponent(noneOfIndices));
        }
    }
}