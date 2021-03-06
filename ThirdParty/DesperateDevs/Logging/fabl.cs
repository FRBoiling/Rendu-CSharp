﻿using System;
using System.Collections.Generic;

namespace DesperateDevs.Logging
{
    public static class fabl
    {
        private static readonly Dictionary<string, Logger> _loggers = new Dictionary<string, Logger>();
        private static readonly Logger _logger = GetLogger(nameof(fabl));
        private static LogLevel _globalLogLevel;
        private static LogDelegate _appenders;

        public static LogLevel globalLogLevel
        {
            get => _globalLogLevel;
            set
            {
                _globalLogLevel = value;
                foreach (var logger in _loggers.Values)
                    logger.logLevel = value;
            }
        }

        public static void Trace(string message)
        {
            _logger.Trace(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void Assert(bool condition, string message)
        {
            _logger.Assert(condition, message);
        }

        public static void AddAppender(LogDelegate appender)
        {
            _appenders += appender;
            foreach (var logger in _loggers.Values)
                logger.OnLog += appender;
        }

        public static void RemoveAppender(LogDelegate appender)
        {
            _appenders -= appender;
            foreach (var logger in _loggers.Values)
                logger.OnLog -= appender;
        }

        public static Logger GetLogger(Type type)
        {
            return GetLogger(type.FullName);
        }

        public static Logger GetLogger(string name)
        {
            Logger logger;
            if (!_loggers.TryGetValue(name, out logger))
            {
                logger = new Logger(name);
                logger.logLevel = globalLogLevel;
                logger.OnLog += _appenders;
                _loggers.Add(name, logger);
            }

            return logger;
        }

        public static void ResetLoggers()
        {
            _loggers.Clear();
        }

        public static void ResetAppenders()
        {
            _appenders = null;
        }
    }
}