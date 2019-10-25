using Entitas;

public class ContextGetGroup : IPerformanceTest
{
    private const int n = 100000;
    private IContext<Entity> _context;

    public void Before()
    {
        _context = Helper.CreateContext();
    }

    public void Run()
    {
        var m = Matcher<Entity>.AllOf(CP.ComponentA);
        for (var i = 0; i < n; i++) _context.GetGroup(m);
    }
}