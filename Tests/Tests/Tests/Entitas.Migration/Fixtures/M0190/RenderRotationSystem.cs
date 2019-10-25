using Entitas;

public class RenderRotationSystem : IReactiveSystem
{
    public IMatcher trigger => Matcher.AllOf(CoreMatcher.Rotation, CoreMatcher.View);

    public GroupEventType eventType => GroupEventType.OnEntityAdded;

    public void Execute(Entity[] entities)
    {
        // Do sth
    }
}