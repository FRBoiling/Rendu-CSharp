public partial class TestEntity 
{

    public Components.NameComponent name { get { return (Components.NameComponent)GetComponent(TestComponentsLookup.Name); } }
    public bool hasName { get { return HasComponent(TestComponentsLookup.Name); } }

    public void AddName(string newValue)
    {
        var index = TestComponentsLookup.Name;
        var component = (Components.NameComponent)CreateComponent(index, typeof(Components.NameComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceName(string newValue) 
    {
        var index = TestComponentsLookup.Name;
        var component = (Components.NameComponent)CreateComponent(index, typeof(Components.NameComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveName() 
    {
        RemoveComponent(TestComponentsLookup.Name);
    }
}


public sealed partial class TestMatcher 
{

    static Entitas.Matcher.IMatcher<TestEntity> _matcherName;

    public static Entitas.Matcher.IMatcher<TestEntity> Name 
    {
        get 
        {
            if (_matcherName == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<TestEntity>)Entitas.Matcher.Matcher<TestEntity>.AllOf(TestComponentsLookup.Name);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherName = matcher;
            }
            return _matcherName;
        }
    }
}
