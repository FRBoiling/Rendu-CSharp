using Entitas;
using Entitas.CodeGeneration.Attributes;

[Context("Test")]
public class NormalComponent : IComponent
{
    public int Value;
}

[Context("Test")]
[Unique]
public class UniqueComponent : IComponent
{
    public int Value;
}

[Context("Test")]
[FlagPrefix("flag")]
public class DestroyComponent : IComponent
{
}

[Context("Test")]
public class NameComponent : IComponent
{
    [PrimaryEntityIndex]
    public string value;
}

[Context("Test")]
public class PlayerComponent : IComponent
{
    [EntityIndex]
    public string name;
}

[DontGenerate]
public class ChannelComponent : IComponent
{
    public int id;
}

//[Context("Test"),ComponentName("Position", "Velocity")]
//public struct IntVector2
//{
//    public int x;
//    public int y;
//}

//[Cleanup(CleanupMode.DestroyEntity)]
//public sealed class DestroyedComponent : IComponent
//{
//}
