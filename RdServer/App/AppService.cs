using System;
using AppFrame;
using Entitas;

namespace Server
{
    public class AppService : IService
    {
        public static AppService Inst = new AppService();

        Systems _systems;

        bool isRun = false;

        public void Run(string[] args)
        {
            Start(args);
            Update();
        }

        public void Start(string[] args)
        {
            if (!ArgsAnalysis(args, out var appType, out var mainKey, out var subKey))
            {
                return;
            }

            // 获取当前的环境组Contexts，里面有game环境和input环境
            var contexts = Contexts.sharedInstance;

            // 创建系统集，将自定义的系统集添加进去
            _systems = new Feature("System");
            _systems.Add(new AppFeatureSystems(contexts,appType,mainKey,subKey));

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

        public bool ArgsAnalysis(string[] args, out AppType appType, out int mainKey, out int subKey)
        {
            appType = AppType.Server;
            mainKey = 0;
            subKey = 0;
            int count = args.Length;
            if (count < 1)
            {
                return false;
            }
            appType = (AppType)Enum.Parse(typeof(AppType), args[0]);
            if (count < 2)
            {
                return false; ;
            }
            mainKey = int.Parse(args[1]);
            if (count >= 3)
            {
                subKey = int.Parse(args[2]);
            }
            return true;
        }

    }
}
