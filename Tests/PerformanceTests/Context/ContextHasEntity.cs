using Entitas;

public class ContextHasEntity : IPerformanceTest
{
    private const int n = 100000;
    private IContext<Entity> _context;
    private Entity _e;

    public void Before()
    {
        _context = Helper.CreateContext();
        for (var i = 0; i < n; i++) _context.CreateEntity();
        _e = _context.CreateEntity();
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _context.HasEntity(_e);
    }
}