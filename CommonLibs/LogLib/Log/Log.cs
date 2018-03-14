using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    public class Log
    {
        private static ILog _log;
        public static void InitLog(ILog logger)
        {
            _log = logger;
        }
        public static void Close()
        {
            _log.Close();
        }

        public static void Write(string format, params object[] args)
        {
            _log.Write(format,args);
        }
        public static void Warn(string format, params object[] args)
        {
            _log.Warn(format, args);
        }
        public static void Error(string format, params object[] args)
        {
            _log.Error(format, args);
        }
        public static void Info(string format, params object[] args)
        {
            _log.Info(format, args);
        }
        public static void Debug(string format, params object[] args)
        {
            _log.Debug(format, args);
        }

    }
}
