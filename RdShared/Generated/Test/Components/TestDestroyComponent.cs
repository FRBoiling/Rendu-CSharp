public partial class TestEntity {

    static readonly Components.DestroyComponent destroyComponent = new Components.DestroyComponent();

    public bool flagDestroy {
        get { return HasComponent(TestComponentsLookup.Destroy); }
        set {
            if (value != flagDestroy) {
                var index = TestComponentsLookup.Destroy;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : destroyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}


public sealed partial class TestMatcher 
{

    static Entitas.Matcher.IMatcher<TestEntity> _matcherDestroy;

    public static Entitas.Matcher.IMatcher<TestEntity> Destroy 
    {
        get 
        {
            if (_matcherDestroy == null) 
            {
                var matcher = (Entitas.Matcher.Matcher<TestEntity>)Entitas.Matcher.Matcher<TestEntity>.AllOf(TestComponentsLookup.Destroy);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherDestroy = matcher;
            }
            return _matcherDestroy;
        }
    }
}
