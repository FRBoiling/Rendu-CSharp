using Entitas;

public class EntityReplaceComponent : IPerformanceTest
{
    private const int n = 1000000;
    private IContext<Entity> _context;
    private IEntity _e;

    public void Before()
    {
        _context = Helper.CreateContext();
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentB));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentC));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentB));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentC));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentB, CP.ComponentC));
        _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentB, CP.ComponentC));
        _e = _context.CreateEntity();
        _e.AddComponent(CP.ComponentA, new ComponentA());
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _e.ReplaceComponent(CP.ComponentA, new ComponentA());
    }
}