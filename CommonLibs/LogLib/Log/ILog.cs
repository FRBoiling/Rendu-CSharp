using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    public interface ILog
    {
        void Write(string format,params object[] args);
        void Warn(string format,params object[] args);
        void Error(string format,params object[] args);
        void Info(string format,params object[] args);
        void Debug(string format, params object[] args);
        void Close();


    }
}
