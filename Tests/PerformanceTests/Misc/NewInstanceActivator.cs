using System;

public class NewInstanceActivator : IPerformanceTest
{
    private const int n = 1000000;

    private Type _type;

    public void Before()
    {
        _type = typeof(ComponentA);
    }

    public void Run()
    {
        for (var i = 0; i < n; i++) createInstance();
    }

    private void createInstance()
    {
        Activator.CreateInstance(_type);
    }
}