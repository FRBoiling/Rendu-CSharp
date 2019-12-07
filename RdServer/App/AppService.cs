using System;
using AppFrame;
using Entitas;

namespace Server
{
    public class AppService : IService
    {
        public static AppService Inst = new AppService();
        Systems _systems;

        private AppService()
        {

        }

        bool isRun = false;
        
        public void Run(string[] args)
        {
            Start();
            Update();
        }

        public void Start()
        {
            // 获取当前的环境组Contexts，里面有game环境和input环境
            var contexts = Contexts.sharedInstance;

            // 创建系统集，将自定义的系统集添加进去
            _systems = new Feature("System")
                .Add(new GateFeatureSystem(contexts))
                .Add(new ZoneFeatureSystem(contexts));

            // 初始化，会执行所有实现IInitialzeSystem的Initialize方法
            _systems.Initialize();
            isRun = true;
        }

        public void Stop()
        {
            //TODO:BOILING  做关闭退出逻辑
            isRun = false;
        }

        public void Update()
        {
            while (isRun)
            {
                // 执行系统集中的所有Execute方法
                _systems.Execute();

                //  执行系统集中的所有Cleanup方法
                _systems.Cleanup();
            }
        }
    }
}
