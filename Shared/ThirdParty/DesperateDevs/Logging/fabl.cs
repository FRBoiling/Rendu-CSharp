using System;
using System.Collections.Generic;

namespace DesperateDevs.Logging
{
  public static class fabl
  {
    private static readonly Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>();
    private static readonly Logger _logger = fabl.GetLogger(nameof (fabl));
    private static LogLevel _globalLogLevel;
    private static LogDelegate _appenders;

    public static LogLevel globalLogLevel
    {
      get
      {
        return fabl._globalLogLevel;
      }
      set
      {
        fabl._globalLogLevel = value;
        foreach (Logger logger in fabl._loggers.Values)
          logger.logLevel = value;
      }
    }

    public static void Trace(string message)
    {
      fabl._logger.Trace(message);
    }

    public static void Debug(string message)
    {
      fabl._logger.Debug(message);
    }

    public static void Info(string message)
    {
      fabl._logger.Info(message);
    }

    public static void Warn(string message)
    {
      fabl._logger.Warn(message);
    }

    public static void Error(string message)
    {
      fabl._logger.Error(message);
    }

    public static void Fatal(string message)
    {
      fabl._logger.Fatal(message);
    }

    public static void Assert(bool condition, string message)
    {
      fabl._logger.Assert(condition, message);
    }

    public static void AddAppender(LogDelegate appender)
    {
      fabl._appenders += appender;
      foreach (Logger logger in fabl._loggers.Values)
        logger.OnLog += appender;
    }

    public static void RemoveAppender(LogDelegate appender)
    {
      fabl._appenders -= appender;
      foreach (Logger logger in fabl._loggers.Values)
        logger.OnLog -= appender;
    }

    public static Logger GetLogger(Type type)
    {
      return fabl.GetLogger(type.FullName);
    }

    public static Logger GetLogger(string name)
    {
      Logger logger;
      if (!fabl._loggers.TryGetValue(name, out logger))
      {
        logger = new Logger(name);
        logger.logLevel = fabl.globalLogLevel;
        logger.OnLog += fabl._appenders;
        fabl._loggers.Add(name, logger);
      }
      return logger;
    }

    public static void ResetLoggers()
    {
      fabl._loggers.Clear();
    }

    public static void ResetAppenders()
    {
      fabl._appenders = (LogDelegate) null;
    }
  }
}