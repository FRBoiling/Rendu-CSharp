namespace DesperateDevs.Logging
{
    public delegate void LogDelegate(Logger logger, LogLevel logLevel, string message);

    public class Logger
    {
        public event LogDelegate OnLog;

        public LogLevel logLevel { get; set; }

        public string name { get; private set; }

        public Logger(string name)
        {
            this.name = name;
        }

        public void Trace(string message)
        {
            this.log(LogLevel.Trace, message);
        }

        public void Debug(string message)
        {
            this.log(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            this.log(LogLevel.Info, message);
        }

        public void Warn(string message)
        {
            this.log(LogLevel.Warn, message);
        }

        public void Error(string message)
        {
            this.log(LogLevel.Error, message);
        }

        public void Fatal(string message)
        {
            this.log(LogLevel.Fatal, message);
        }

        public void Assert(bool condition, string message)
        {
            if (!condition)
                throw new FablAssertException(message);
        }

        private void log(LogLevel logLvl, string message)
        {
            if (this.OnLog == null || this.logLevel > logLvl)
                return;
            this.OnLog(this, logLvl, message);
        }

        public void Reset()
        {
            this.OnLog = (LogDelegate) null;
        }
    }
}