using System.Collections.Generic;
using Entitas;

public sealed class AddViewFromObjectPoolSystem : ISetPool, IReactiveSystem, IEnsureComponents, IExcludeComponents
{
    private Transform _container;

    private Pool _pool;

    public TriggerOnEvent trigger => BulletsMatcher.ViewObjectPool.OnEntityRemoved();

    public IMatcher ensureComponents => Matcher.AllOf(BulletsMatcher.ViewObjectPool, BulletsMatcher.Position);

    public IMatcher excludeComponents => Matcher<TestEntity>.AnyOf(BulletsMatcher.Destroy, BulletsMatcher.Destroy);

    public void SetPool(Context pool)
    {
        _pool = pool;
    }

    public void SetPools(Contexts pools)
    {
        _pools = pools;
    }

    public void Initialize()
    {
    }

    public void Execute(List<Entity> entities)
    {
    }
}


public sealed class MoveSystem : ISetPool, IExecuteSystem
{
    private Group _group;

    public void Execute()
    {
        foreach (var e in _group.GetEntities())
        {
            var move = e.move;
            var pos = e.position;
            e.ReplacePosition(pos.x, pos.y + move.speed, pos.z);
        }
    }

    public void SetPool(Context pool)
    {
        _group = pool.GetGroup(Matcher.AllOf(GameMatcher.Move, GameMatcher.Position));
    }
}