using Entitas.Context;
public partial class Contexts : IContexts 
{
    public static Contexts sharedInstance 
    {
        get 
        {
            if (_sharedInstance == null)
            {
                _sharedInstance = new Contexts();
            }
            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public TestContext test { get; set; }

    public IContext[] allContexts { get { return new IContext [] { test }; } }

    public Contexts() 
    {
        test = new TestContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors)
        {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() 
    {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) 
        {
            contexts[i].Reset();
        }
    }
}

public partial class Contexts 
{

    public const string Name = "Name";
    public const string Player = "Player";

    [Entitas.Attributes.PostConstructor]
    public void InitializeEntityIndices() 
    {
        test.AddEntityIndex(new Entitas.PrimaryEntityIndex<TestEntity, string>(
            Name,
            test.GetGroup(TestMatcher.Name),
            (e, c) => ((Components.NameComponent)c).value));

        test.AddEntityIndex(new Entitas.EntityIndex<TestEntity, string>(
            Player,
            test.GetGroup(TestMatcher.Player),
            (e, c) => ((Components.PlayerComponent)c).name));
    }
}

public static class ContextsExtensions 
{
    public static TestEntity GetEntityWithName(this TestContext context, string value) {
        return ((Entitas.PrimaryEntityIndex<TestEntity, string>)context.GetEntityIndex(Contexts.Name)).GetEntity(value);
    }

    public static System.Collections.Generic.HashSet<TestEntity> GetEntitiesWithPlayer(this TestContext context, string name) {
        return ((Entitas.EntityIndex<TestEntity, string>)context.GetEntityIndex(Contexts.Player)).GetEntities(name);
    }
}