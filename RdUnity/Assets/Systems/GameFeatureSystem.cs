using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameFeatureSystem : Feature
{
    // 添加所有要用到的System，base里面是调试节点的名字
    public GameFeatureSystem(Contexts contexts) : base("GameFeature Systems")
    {
        Add(new InitGameContextSystem(contexts));
        Add(new DebugMessageSystem(contexts));
    }
}
