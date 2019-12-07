using Entitas;
using Entitas.Collector;
using Entitas.Context;
using Entitas.Group;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Systems.Gate
{
    // 继承ReactiveSystem，功能是只要Component的值一发生变化，其中的Execute就会执行
    public class GateInfoReactiveSystem : ReactiveSystem<GateEntity>
    {
        // 将环境中的game环境传入，GameEntity当然是放在game环境中的
        public GateInfoReactiveSystem(Contexts contexts) : base(contexts.gate) { }

        // 过滤获取指定Component的Entity
        protected override ICollector<GateEntity> GetTrigger(IContext<GateEntity> context)
        {
            // 返回过滤器
            return context.CreateCollector(GateMatcher.Info);
        }

        // 最终检查，判断成功才能执行
        protected override bool Filter(GateEntity entity)
        {
            return entity.hasInfo;
        }

        // 过滤到的Component统一执行操作
        protected override void Execute(List<GateEntity> entities)
        {
            throw new NotImplementedException();
        }
    }

    public class GateInfoCleanupSystem : ICleanupSystem
    {
        // 保存game环境
        readonly GateContext _context;
        // 保存所有拥有DebugMessage组件的Entity
        readonly IGroup<GateEntity> _debugMessages;

        // 构造函数，添加game环境和保存拥有DebugMessage组件的Group
        public GateInfoCleanupSystem(Contexts contexts)
        {
            _context = contexts.gate;
            _debugMessages = _context.GetGroup(GateMatcher.Info);
        }

        // Cleanup函数，只要有DebugMessage组件的Entity就直接销毁
        public void Cleanup()
        {
            foreach (var e in _debugMessages.GetEntities())
            {
                e.Destroy();
            }
        }
    }
}
