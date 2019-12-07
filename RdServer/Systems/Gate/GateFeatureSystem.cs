using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class GateFeatureSystem: Feature
    {
        // 添加所有要用到的System，base里面是调试节点的名字
        public GateFeatureSystem(Contexts contexts) : base("GateFeature Systems")
        {
            //Add(new GameContextInitSystem(contexts));
            ////Add(new DebugMessageCleanupSystem(contexts));
            //Add(new MouseClickExecuteSystem(contexts));
            //Add(new MouseClickReactiveSystem(contexts));
            //Add(new DebugMessageReactiveSystem(contexts));
        }
    }
}
