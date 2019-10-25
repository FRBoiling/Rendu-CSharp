using Entitas;

public class ContextCreateEntity : IPerformanceTest
{
    private const int n = 100000;
    private IContext<Entity> _context;

    public void Before()
    {
        _context = Helper.CreateContext();
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _context.CreateEntity();
    }
}