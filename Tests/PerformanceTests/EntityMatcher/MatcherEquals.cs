using Entitas;

public class MatcherEquals : IPerformanceTest
{
    private const int n = 10000000;
    private IMatcher<Entity> _m1;
    private IMatcher<Entity> _m2;

    public void Before()
    {
        _m1 = Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentB, CP.ComponentC);
        _m2 = Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentB, CP.ComponentC);
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _m1.Equals(_m2);
    }
}