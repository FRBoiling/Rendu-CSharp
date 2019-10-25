using Entitas;

public class ContextCreateBlueprint : IPerformanceTest
{
    private const int n = 100000;
    private Blueprint _blueprint;
    private IContext<Entity> _context;

    public void Before()
    {
        _context = Helper.CreateContext();

        var e = _context.CreateEntity();
        var component = new NameAgeComponent();
        component.name = "Max";
        component.age = 42;
        e.AddComponent(CP.ComponentA, component);

        _blueprint = new Blueprint(string.Empty, string.Empty, e);
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _context.CreateEntity().ApplyBlueprint(_blueprint);
    }
}

public class NameAgeComponent : IComponent
{
    public int age;
    public string name;
}