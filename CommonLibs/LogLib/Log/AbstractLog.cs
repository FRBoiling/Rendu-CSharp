using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLib
{
    public abstract class AbstractLog : ILog
    {
        private string GetString(string format, params object[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(format,args);
            return sb.ToString();
        }

        public void Debug(string format, params object[] args)
        {
            Debug(GetString(format, args));
        }

        public void Error(string format, params object[] args)
        {
            Error(GetString(format, args));
        }

        public void Info(string format, params object[] args)
        {
            Info(GetString(format, args));
        }

        public void Warn(string format, params object[] args)
        {
            Warn(GetString(format, args));
        }

        public void Write(string format, params object[] args)
        {
            Write(GetString(format, args));
        }

        public abstract void Write(string log);
        public abstract void Warn(string log);
        public abstract void Error(string log);
        public abstract void Info(string log);
        public abstract void Debug(string log);
        public abstract void Close();
    }
}
