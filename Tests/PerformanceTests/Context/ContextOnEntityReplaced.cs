using Entitas;

public class ContextOnEntityReplaced : IPerformanceTest
{
    private const int n = 100000;
    private IContext<Entity> _context;
    private IEntity _e;

    public void Before()
    {
        _context = Helper.CreateContext();
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA));
        _e = _context.CreateEntity();
        _e.AddComponent(CP.ComponentA, new ComponentA());
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _e.ReplaceComponent(CP.ComponentA, new ComponentA());
    }
}