using Entitas;

// 继承于IInitializeSystem，作用是在程序启动时，执行一次Initialize方法
public class InitGameContextSystem : IInitializeSystem
{
    // game环境
    readonly GameContext _context;

    // 创建时传入game的环境
    public InitGameContextSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    // 初始化方法
    public void Initialize()
    {
        // 在game环境中创建一个Entity，并在Entity上添加一个DebugMessageComponent，内容是Hello World
        _context.CreateEntity().AddDebugMessage("Hello World!");
    }
}

