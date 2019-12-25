public partial class TestEntity 
{

    public Components.PlayerComponent player { get { return (Components.PlayerComponent)GetComponent(TestComponentsLookup.Player); } }
    public bool hasPlayer { get { return HasComponent(TestComponentsLookup.Player); } }

    public void AddPlayer(string newName)
    {
        var index = TestComponentsLookup.Player;
        var component = (Components.PlayerComponent)CreateComponent(index, typeof(Components.PlayerComponent));
        component.name = newName;
        AddComponent(index, component);
    }

    public void ReplacePlayer(string newName) 
    {
        var index = TestComponentsLookup.Player;
        var component = (Components.PlayerComponent)CreateComponent(index, typeof(Components.PlayerComponent));
        component.name = newName;
        ReplaceComponent(index, component);
    }

    public void RemovePlayer() 
    {
        RemoveComponent(TestComponentsLookup.Player);
    }
}


public sealed partial class TestMatcher 
{

    static Entitas.Matcher.IMatcher<TestEntity> _matcherPlayer;

    public static Entitas.Matcher.IMatcher<TestEntity> Player 
    {
        get 
        {
            if (_matcherPlayer == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<TestEntity>)Entitas.Matcher.Matcher<TestEntity>.AllOf(TestComponentsLookup.Player);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherPlayer = matcher;
            }
            return _matcherPlayer;
        }
    }
}
