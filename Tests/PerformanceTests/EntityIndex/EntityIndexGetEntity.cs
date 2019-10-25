using Entitas;

public class EntityIndexGetEntity : IPerformanceTest
{
    private const int n = 1000000;

    private IContext<Entity> _context;

    private PrimaryEntityIndex<Entity, string> _index;

    public void Before()
    {
        _context = Helper.CreateContext();
        _index = new PrimaryEntityIndex<Entity, string>("TestIndex", _context.GetGroup(Matcher<Entity>.AllOf(CP.ComponentA)), (e, c) => ((NameComponent) c).name);

        for (var i = 0; i < 10; i++)
        {
            var nameComponent = new NameComponent();
            nameComponent.name = i.ToString();
            _context.CreateEntity().AddComponent(CP.ComponentA, nameComponent);
        }
    }

    public void Run()
    {
        var name = 9.ToString();
        for (var i = 0; i < n; i++) _index.GetEntity(name);
    }
}