using Entitas;

public class TearDownSystemSpy : ITearDownSystem
{
    public int didTearDown { get; private set; }

    public void TearDown()
    {
        didTearDown += 1;
    }
}