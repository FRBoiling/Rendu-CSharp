using Entitas;

public class Casting : IPerformanceTest
{
    private const int n = 50000000;
    private IAERC _aerc;

    public void Before()
    {
        _aerc = new SafeAERC(null);
    }

    public void Run()
    {
        for (var i = 0; i < n; i++)
        {
            //var x = _aerc.retainCount;

            //var x = _aerc as SafeAERC;
            //if (x != null) {

            //}

            var x = (UnsafeAERC) _aerc;
        }
    }
}