using System;
using System.Threading;
using Entitas.Entity;
using Entitas.Group;

namespace Entitas.Systems
{
    /// A JobSystem calls Execute(entities) with subsets of entities
    /// and distributes the workload over the specified amount of threads.
    /// Don't use the generated methods like AddXyz() and ReplaceXyz() when
    /// writing multi-threaded code in Entitas.
    public abstract class JobSystem<TEntity> : IExecuteSystem where TEntity : class, IEntity
    {
        private readonly IGroup<TEntity> _group;
        private readonly Job<TEntity>[] _jobs;
        private readonly int _threads;

        private int _threadsRunning;

        protected JobSystem(IGroup<TEntity> group, int threads)
        {
            _group = group;
            _threads = threads;
            _jobs = new Job<TEntity>[threads];
            for (var i = 0; i < _jobs.Length; i++) _jobs[i] = new Job<TEntity>();
        }

        protected JobSystem(IGroup<TEntity> group) : this(group, Environment.ProcessorCount)
        {
        }

        public virtual void Execute()
        {
            _threadsRunning = _threads;
            var entities = _group.GetEntities();
            var remainder = entities.Length % _threads;
            var slice = entities.Length / _threads + (remainder == 0 ? 0 : 1);
            for (var t = 0; t < _threads; t++)
            {
                var from = t * slice;
                var to = from + slice;
                if (to > entities.Length) to = entities.Length;

                var job = _jobs[t];
                job.Set(entities, from, to);
                if (from != to)
                    ThreadPool.QueueUserWorkItem(queueOnThread, _jobs[t]);
                else
                    Interlocked.Decrement(ref _threadsRunning);
            }

            while (_threadsRunning != 0)
            {
            }

            foreach (var job in _jobs)
                if (job.exception != null)
                    throw job.exception;
        }

        private void queueOnThread(object state)
        {
            var job = (Job<TEntity>) state;
            try
            {
                for (var i = job.from; i < job.to; i++) Execute(job.entities[i]);
            }
            catch (Exception ex)
            {
                job.exception = ex;
            }
            finally
            {
                Interlocked.Decrement(ref _threadsRunning);
            }
        }

        protected abstract void Execute(TEntity entity);
    }
}