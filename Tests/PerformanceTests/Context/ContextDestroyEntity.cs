using Entitas;

public class ContextDestroyEntity : IPerformanceTest
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
        var entities = _context.GetEntities();
        for (var i = 0; i < entities.Length; i++) entities[i].Destroy();
    }
}