using System;

namespace Entitas
{
    internal class Job<TEntity> where TEntity : class, IEntity
    {
        public TEntity[] entities;
        public Exception exception;
        public int from;
        public int to;

        public void Set(TEntity[] entities, int from, int to)
        {
            this.entities = entities;
            this.from = from;
            this.to = to;
            exception = null;
        }
    }
}