using Entitas;

[Context("Test")]
[Context("Test2")]
public sealed class NameAgeComponent : IComponent
{
    public int age;

    public string name;

    public override string ToString()
    {
        return "NameAge(" + name + ", " + age + ")";
    }
}