public partial class TestContext 
{

    public TestEntity uniqueEntity { get { return GetGroup(TestMatcher.Unique).GetSingleEntity(); } }
    public Components.UniqueComponent unique { get { return uniqueEntity.unique; } }
    public bool hasUnique { get { return uniqueEntity != null; } }

    public TestEntity SetUnique(int newValue) 
    {
        if (hasUnique)
        {
            throw new Entitas.EntitasException("Could not set Unique!\n" + this + " already has an entity with Components.UniqueComponent!",
                "You should check if the context already has a uniqueEntity before setting it or use context.ReplaceUnique().");
        }
        var entity = CreateEntity();
        entity.AddUnique(newValue);
        return entity;
    }

    public void ReplaceUnique(int newValue) 
    {
        var entity = uniqueEntity;
        if (entity == null) {
            entity = SetUnique(newValue);
        } else {
            entity.ReplaceUnique(newValue);
        }
    }

    public void RemoveUnique() 
    {
        uniqueEntity.Destroy();
    }
}

public partial class TestEntity 
{

    public Components.UniqueComponent unique { get { return (Components.UniqueComponent)GetComponent(TestComponentsLookup.Unique); } }
    public bool hasUnique { get { return HasComponent(TestComponentsLookup.Unique); } }

    public void AddUnique(int newValue)
    {
        var index = TestComponentsLookup.Unique;
        var component = (Components.UniqueComponent)CreateComponent(index, typeof(Components.UniqueComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnique(int newValue) 
    {
        var index = TestComponentsLookup.Unique;
        var component = (Components.UniqueComponent)CreateComponent(index, typeof(Components.UniqueComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnique() 
    {
        RemoveComponent(TestComponentsLookup.Unique);
    }
}


public sealed partial class TestMatcher 
{

    static Entitas.Matcher.IMatcher<TestEntity> _matcherUnique;

    public static Entitas.Matcher.IMatcher<TestEntity> Unique 
    {
        get 
        {
            if (_matcherUnique == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<TestEntity>)Entitas.Matcher.Matcher<TestEntity>.AllOf(TestComponentsLookup.Unique);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherUnique = matcher;
            }
            return _matcherUnique;
        }
    }
}
