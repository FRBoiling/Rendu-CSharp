using Entitas;

public class CleanupSystemSpy : ICleanupSystem
{
    public int didCleanup { get; private set; }

    public void Cleanup()
    {
        didCleanup += 1;
    }
}