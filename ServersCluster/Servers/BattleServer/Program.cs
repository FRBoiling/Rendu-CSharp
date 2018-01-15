using BattleServerLib;
using ServerFrameWork;
using System;
using System.Threading;

namespace BattleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Api api = new Api();
            AbstractServer _api = new Api();
            try
            {
                _api.ApiTag.Type = ServerType.Battle;
                _api.Init(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} init failed:{1}", _api.ApiTag.Type, e.ToString());
                _api.Exit();
                return;
            }

            Thread thread = new Thread(_api.MainLoop);
            thread.Start();

            Console.WriteLine("{0} OnReady..", _api.ApiTag.GetServerTagString());

            while (thread.IsAlive)
            {
                _api.ProcessInput();
                Thread.Sleep(1000);
            }

            _api.Exit();
            Console.WriteLine("{0} Exit..", _api.ApiTag.GetServerTagString());
        }
    }
}
