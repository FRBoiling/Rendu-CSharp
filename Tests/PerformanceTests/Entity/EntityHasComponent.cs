using Entitas;

public class EntityHasComponent : IPerformanceTest
{
    private const int n = 1000000;
    private IEntity _e;

    public void Before()
    {
        var context = Helper.CreateContext();
        _e = context.CreateEntity();
        _e.AddComponent(CP.ComponentA, new ComponentA());
        _e.AddComponent(CP.ComponentB, new ComponentB());
        _e.AddComponent(CP.ComponentC, new ComponentC());
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _e.HasComponent(CP.ComponentA);
    }
}