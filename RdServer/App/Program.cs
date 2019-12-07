using AppFrame;

namespace Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AppService.Inst.Run(args);
        }
    }
}