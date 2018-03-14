using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    //public enum LogType
    //{
    //    public const string WRITE = "[WRITE]";
    //    public const string INFO = "[INFO]";
    //    public const string WARN = "[WARN]";
    //    public const string ERROR = "[ERROR]";
    //    public const string DEBUG = "[DEBUG]";
    //}

    public enum LogType
    {
        ERROR = 0,
        WARN = 1,
        INFO = 2,
        WRITE = 3,  //只写到console
        DEBUG = 4,  //只在debug时候
    }
}
