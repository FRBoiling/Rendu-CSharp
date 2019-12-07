using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class ZoneFeatureSystem: Feature
    {
        // 添加所有要用到的System，base里面是调试节点的名字
        public ZoneFeatureSystem(Contexts contexts) : base("ZoneFeature Systems")
        {
            //Add(new GameContextInitSystem(contexts));
            ////Add(new DebugMessageCleanupSystem(contexts));
            //Add(new MouseClickExecuteSystem(contexts));
            //Add(new MouseClickReactiveSystem(contexts));
            //Add(new DebugMessageReactiveSystem(contexts));
        }
    }
}
