public class NewInstanceT : IPerformanceTest
{
    private const int n = 1000000;

    public void Before()
    {
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) createInstance<ComponentA>();
    }

    private void createInstance<T>() where T : new()
    {
        new T();
    }
}