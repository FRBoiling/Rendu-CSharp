using Entitas;

public class InitializeSystemSpy : IInitializeSystem
{
    public int didInitialize { get; private set; }

    public void Initialize()
    {
        didInitialize += 1;
    }
}