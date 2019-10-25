using Entitas;

public class PrimaryEntityIndexComponent : IComponent
{
    [PrimaryEntityIndex] public string value;
}