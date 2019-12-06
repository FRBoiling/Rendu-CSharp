using Entitas;
using UnityEngine;
using System.Collections.Generic;

// 继承ReactiveSystem，功能是只要Component的值一发生变化，其中的Execute就会执行
public class DebugMessageSystem : ReactiveSystem<GameEntity>
{
    // 将环境中的game环境传入，GameEntity当然是放在game环境中的
    public DebugMessageSystem(Contexts contexts) : base(contexts.game) { }

    // 过滤获取指定Component的Entity，这里必须是拥有DebugMessageComponent的Entity才能被提取
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        // 返回过滤器
        return context.CreateCollector(GameMatcher.DebugMessage);
    }

    // 最终检查，判断成功才能执行
    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDebugMessage;
    }

    // 过滤到的Component统一执行操作
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log(e.debugMessage.message);
        }
    }
}
