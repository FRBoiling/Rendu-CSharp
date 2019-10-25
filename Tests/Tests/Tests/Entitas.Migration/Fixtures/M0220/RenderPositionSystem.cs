using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : IReactiveSystem
{
    public IMatcher trigger => Matcher.AllOf(Matcher.Position, Matcher.View);

    public GroupEventType
        eventType =>
        GroupEventType.OnEntityAdded;

    public void Execute(List<Entity> entities)
    {
    }
}