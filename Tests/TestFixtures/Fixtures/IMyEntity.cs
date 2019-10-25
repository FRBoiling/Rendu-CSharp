using Entitas;

public interface IMyEntity : IEntity, INameAgeEntity
{
}

public partial class TestEntity : IMyEntity
{
}

public partial class Test2Entity : IMyEntity
{
}