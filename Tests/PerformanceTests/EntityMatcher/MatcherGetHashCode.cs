using Entitas;

public class MatcherGetHashCode : IPerformanceTest
{
    private const int n = 10000000;
    private IMatcher<Entity> _m;

    public void Before()
    {
        _m = Matcher<Entity>.AllOf(CP.ComponentA, CP.ComponentB, CP.ComponentC);
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) _m.GetHashCode();
    }
}