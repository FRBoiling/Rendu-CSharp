using Entitas;

public class ObjectGetProperty : IPerformanceTest
{
    private const int n = 10000000;
    private IContext<Entity> _context;

    public void Before()
    {
        _context = new Context<Entity>(1, () => new Entity());
    }

    public void Run()
    {
        for (var i = 0; i < n; i++)
        {
            var c = _context.totalComponents;
        }
    }
}