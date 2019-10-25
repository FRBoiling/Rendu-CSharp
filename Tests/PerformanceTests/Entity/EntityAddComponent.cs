using Entitas;

#pragma warning disable
public class EntityAddComponent : IPerformanceTest
{
    private const int n = 10000000;
    private ComponentA _componentA;
    private IEntity _e;

    public void Before()
    {
        var context = Helper.CreateContext();
        _e = context.CreateEntity();
        _componentA = new ComponentA();
    }

    public void Run()
    {
        for (var i = 0; i < n; i++)
        {
            _e.AddComponent(CP.ComponentA, _e.CreateComponent(CP.ComponentA, typeof(ComponentA)));
            _e.RemoveComponent(CP.ComponentA);
        }
    }
}