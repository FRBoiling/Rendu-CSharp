//using Entitas;
//using System.Collections.Generic;
//using UnityEngine;

//public class MouseClickReactiveSystem : ReactiveSystem<GameEntity>
//{
//    // 将环境中的game环境传入，GameEntity当然是放在game环境中的
//    public MouseClickReactiveSystem(Contexts contexts) : base(contexts.game) { }

//    // 过滤获取指定Component的Entity，这里必须是拥有DebugMessageComponent的Entity才能被提取
//    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
//    {
//        // 返回过滤器
//        return context.CreateCollector(GameMatcher.MouseClick);
//    }

//    // 最终检查，判断成功才能执行
//    protected override bool Filter(GameEntity entity)
//    {
//        return entity.hasMouseClick;
//    }

//    // 过滤到的Component统一执行操作
//    protected override void Execute(List<GameEntity> entities)
//    {
//        foreach (var e in entities)
//        {
//            switch (e.mouseClick.clickCode)
//            {
//                case 0:
//                    e.ReplaceDebugMessage("Left Mouse Button Clicked");
//                    break;
//                case 1:
//                    e.ReplaceDebugMessage("Right Mouse Button Clicked");
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//}


//public class MouseClickExecuteSystem : IExecuteSystem
//{
//    // game的环境
//    readonly GameContext _context;
//    public MouseClickExecuteSystem(Contexts contexts)
//    {
//        _context = contexts.game;
//    }

//    public void Execute()
//    {
//        // 获取到左右按键，就创建个Entity，并添加一个DebguMessage组件
//        foreach (var e in _context.GetEntities())
//        {
//            if (Input.GetMouseButtonDown(0))
//                e.ReplaceMouseClick(0);
//            if (Input.GetMouseButtonDown(1))
//                e.ReplaceMouseClick(1);
//        }

//    }
//}
