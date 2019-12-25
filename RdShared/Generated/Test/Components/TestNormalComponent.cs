public partial class TestEntity 
{

    public Components.NormalComponent normal { get { return (Components.NormalComponent)GetComponent(TestComponentsLookup.Normal); } }
    public bool hasNormal { get { return HasComponent(TestComponentsLookup.Normal); } }

    public void AddNormal(int newValue)
    {
        var index = TestComponentsLookup.Normal;
        var component = (Components.NormalComponent)CreateComponent(index, typeof(Components.NormalComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceNormal(int newValue) 
    {
        var index = TestComponentsLookup.Normal;
        var component = (Components.NormalComponent)CreateComponent(index, typeof(Components.NormalComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveNormal() 
    {
        RemoveComponent(TestComponentsLookup.Normal);
    }
}


public sealed partial class TestMatcher 
{

    static Entitas.Matcher.IMatcher<TestEntity> _matcherNormal;

    public static Entitas.Matcher.IMatcher<TestEntity> Normal 
    {
        get 
        {
            if (_matcherNormal == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<TestEntity>)Entitas.Matcher.Matcher<TestEntity>.AllOf(TestComponentsLookup.Normal);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherNormal = matcher;
            }
            return _matcherNormal;
        }
    }
}
