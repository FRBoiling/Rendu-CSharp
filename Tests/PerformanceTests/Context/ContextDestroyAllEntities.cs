using Entitas;

public class ContextDestroyAllEntities : IPerformanceTest
{
    private const int n = 100000;
    private IContext<Entity> _context;

    public void Before()
    {
        _context = Helper.CreateContext();
        for (var i = 0; i < n; i++) _context.CreateEntity();
    }

    public void Run()
    {
        _context.DestroyAllEntities();
    }
}