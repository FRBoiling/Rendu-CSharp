using LogLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameWork
{
    public enum ServerState
    {
        Disconnect = 0,
        Connected = 1,
        Starting = 2,
        Running = 3,
        Stopping = 4,
        Stopped = 5
    }
    public abstract class AbstractServer
    {
        ServerInfo _apiTag = new ServerInfo();
        public ServerInfo ApiTag
        {
            get { return _apiTag; }
            set { _apiTag = value; }
        }

        //private Mode _startMode;
        //public Mode StartMode
        //{
        //    get { return _startMode; }
        //    set { _startMode = value; }
        //}

        /// <summary>
        /// 预存当前时间
        /// </summary>
        private static DateTime _now;
        public static DateTime Now
        {
            get { return _now; }
            set { _now = value; }
        }


        /// <summary>
        /// 运行标示
        /// </summary>
        bool _isRuning;
        public bool IsRuning
        {
            get { return _isRuning; }
            set { _isRuning = value; }
        }

        /// <summary>
        /// 帧数
        /// </summary>
        FrameControl _fpsCtrl;
        public FrameControl FpsCtrl
        {
            get { return _fpsCtrl; }
            set { _fpsCtrl = value; }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        ServerState _state;
        public ServerState State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// 服务器关闭时间
        /// </summary>
        DateTime _serverStopTime;
        public DateTime ServerStopTime
        {
            get { return _serverStopTime; }
            set { _serverStopTime = value; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="args"></param>
        public void Init(string[] args)
        {
            //StartMode = Mode.Auto;
            InitLogger();
            InitServer(args);
        }

        /// <summary>
        /// 退出
        /// </summary>
        public void Exit()
        {

            ExitServer();
        }

        /// <summary>
        /// 初始化LOG系统
        /// </summary>
        private void InitLogger()
        {
            var logger = new ConsoleLogger();
            logger.Init(true,@"..\Log\", _apiTag.GetServerTagString());
#if DEBUG
            logger.SetPriority(4);
#else
            logger.SetPriority(2);
#endif

            Log.InitLog(logger);

            Log.Info("InitLogger successed");
        }

        /// <summary>
        /// 主循环
        /// </summary>
        public void MainLoop()
        {
            IsRuning = true;
            FpsCtrl = new FrameControl();
            FpsCtrl.Init();
            while (IsRuning)
            {
                FpsCtrl.SetFrameBegin();
                Now = DateTime.Now;
                Update();
                UpdateProccessInput();
                if (State == ServerState.Stopping)
                {
                    if (ServerStopTime < Now)
                    {
                        State = ServerState.Stopped;
                        Console.WriteLine("{0} stopped!", ApiTag.Type.ToString());
                        //LOG.Error("{0} stopped!", ServerName);
                    }
                }
                FpsCtrl.SetFrameEnd();
            }
        }

        /// <summary>
        /// 初始化模块
        /// </summary>
        /// <param name="args"></param>
        protected abstract void InitServer(string[] args);

        /// <summary>
        /// 退出
        /// </summary>
        public abstract void ExitServer();

        /// <summary>
        /// 更新
        /// </summary>
        protected abstract void Update();


        /// <summary>
        /// 处理GM命令 没有后台 临时用控制台输入替代
        /// </summary>
        protected Queue<string> _cmdList = new Queue<string>();
        /// <summary>
        /// 输入
        /// </summary>
        public void ProcessInput()
        {
            try
            {
                string cmd = Console.ReadLine().ToLower().Trim();
                lock (_cmdList)
                {
                    _cmdList.Enqueue(cmd);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                //LOG.Error(e.ToString());
            }
        }

        private void UpdateProccessInput()
        {
            lock (_cmdList)
            {
                while (_cmdList.Count > 0)
                {
                    try
                    {
                        string cmd = _cmdList.Dequeue();
                        ExcuteCommand(cmd);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
        protected abstract void ExcuteCommand(string cmd);

    }
}
