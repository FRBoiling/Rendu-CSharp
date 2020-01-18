using Entitas;

namespace Server
{
    public class AppContextInitSystem : IInitializeSystem
    {

        // App环境
        readonly AppContext _context;

        public AppContextInitSystem(Contexts contexts)
        {
            _context = contexts.app;
        }


        public void Initialize()
        {
            _context.CreateEntity();
            _context.CreateEntity();
        }
    }

    public class AppInfoInitSystem : IInitializeSystem
    {
        Contexts _contexts;
        AppType _appType;
        int _mainKey;
        int _subKey;

        public AppInfoInitSystem(Contexts contexts, AppType appType, int mainKey, int subKey)  
        {
            _contexts = contexts;
            _appType = appType;
            _mainKey = mainKey;
            _subKey = subKey;
        }

        public void Initialize()
        {
            //foreach (var e in _contexts.app.GetEntities())
            //{
            //    e.ReplaceInfo(_appType,_mainKey,_subKey);
            //}
        }
    }
}
