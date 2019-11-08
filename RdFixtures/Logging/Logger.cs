namespace Rd.Logging
{
    public class Logger
    {
        public Logger(string name)
        {
            this.name = name;
        }

        public LogLevel logLevel { get; set; }

        public string name { get; }
        public event LogDelegate OnLog;

        public void Trace(string message)
        {
            log(LogLevel.Trace, message);
        }

        public void Debug(string message)
        {
            log(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            log(LogLevel.Info, message);
        }

        public void Warn(string message)
        {
            log(LogLevel.Warn, message);
        }

        public void Error(string message)
        {
            log(LogLevel.Error, message);
        }

        public void Fatal(string message)
        {
            log(LogLevel.Fatal, message);
        }

        public void Assert(bool condition, string message)
        {
            if (!condition)
                throw new FablAssertException(message);
        }

        private void log(LogLevel logLvl, string message)
        {
            if (OnLog == null || logLevel > logLvl)
                return;
            OnLog(this, logLvl, message);
        }

        public void Reset()
        {
            OnLog = null;
        }
    }
}