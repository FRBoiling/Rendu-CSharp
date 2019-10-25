using System;
using System.Collections.Generic;
using Entitas;

public class MultiReactiveSystemSpy : MultiReactiveSystem<IMyEntity, Contexts>
{
    protected int _didExecute;
    protected IEntity[] _entities;

    public Action<List<IMyEntity>> executeAction;

    public MultiReactiveSystemSpy(Contexts contexts) : base(contexts)
    {
    }

    public int didExecute => _didExecute;
    public IEntity[] entities => _entities;

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.test.CreateCollector(TestMatcher.NameAge),
            contexts.test2.CreateCollector(Test2Matcher.NameAge)
        };
    }

    protected override bool Filter(IMyEntity entity)
    {
        return true;
    }

    protected override void Execute(List<IMyEntity> entities)
    {
        _didExecute += 1;

        if (entities != null)
            _entities = entities.ToArray();
        else
            _entities = null;

        if (executeAction != null) executeAction(entities);
    }
}