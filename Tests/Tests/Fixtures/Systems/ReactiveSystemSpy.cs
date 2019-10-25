using System;
using System.Collections.Generic;
using Entitas;

public interface IReactiveSystemSpy
{
    int didInitialize { get; }
    int didExecute { get; }
    int didCleanup { get; }
    int didTearDown { get; }
    IEntity[] entities { get; }
}

public class ReactiveSystemSpy : ReactiveSystem<TestEntity>, IReactiveSystemSpy, IInitializeSystem, ICleanupSystem, ITearDownSystem
{
    private readonly Func<TestEntity, bool> _filter;
    protected int _didCleanup;
    protected int _didExecute;

    protected int _didInitialize;
    protected int _didTearDown;
    protected IEntity[] _entities;

    public Action<List<TestEntity>> executeAction;

    public ReactiveSystemSpy(ICollector<TestEntity> collector) : base(collector)
    {
    }

    public ReactiveSystemSpy(ICollector<TestEntity> collector, Func<IEntity, bool> filter) : this(collector)
    {
        _filter = filter;
    }

    public void Cleanup()
    {
        _didCleanup += 1;
    }

    public void Initialize()
    {
        _didInitialize += 1;
    }

    public int didInitialize => _didInitialize;
    public int didExecute => _didExecute;
    public int didCleanup => _didCleanup;
    public int didTearDown => _didTearDown;
    public IEntity[] entities => _entities;

    public void TearDown()
    {
        _didTearDown += 1;
    }

    protected override ICollector<TestEntity> GetTrigger(IContext<TestEntity> context)
    {
        return null;
    }

    protected override bool Filter(TestEntity entity)
    {
        return _filter == null || _filter(entity);
    }

    protected override void Execute(List<TestEntity> entities)
    {
        _didExecute += 1;

        if (entities != null)
            _entities = entities.ToArray();
        else
            _entities = null;

        if (executeAction != null) executeAction(entities);
    }
}