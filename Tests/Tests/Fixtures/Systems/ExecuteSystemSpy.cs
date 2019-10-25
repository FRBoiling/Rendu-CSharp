using Entitas;

public class ExecuteSystemSpy : IExecuteSystem
{
    public int didExecute { get; private set; }

    public void Execute()
    {
        didExecute += 1;
    }
}