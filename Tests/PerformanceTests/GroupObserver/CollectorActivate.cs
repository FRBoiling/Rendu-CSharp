using Entitas;

public class CollectorActivate : IPerformanceTest
{
    private const int n = 10000;
    private ICollector<Entity> _collector;

    public void Before()
    {
        var context = Helper.CreateContext();
        var group = context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA));
        _collector = group.CreateCollector();
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _collector.Activate();
    }
}