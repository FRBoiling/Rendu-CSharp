using System;
using System.IO;

namespace LogLib
{
    public class ConsoleLogger : AbstractLog
    {
        private bool _doConsolePrint=true;
        private bool _doFilePrint = false;
        private int _curPriority = 4;

        private DateTime _now;
        private string _logo = "";

        private string _logDir=@"..\Log\";
        private string _logFileName = "";
        private string _fileNamePrefix = "";
        private const int _logFileMaxSize = 8388608;//文件大小8M
        private StreamWriter _tw;

        private int writeLength = 0;
        private int flushLength = 0;
        private DateTime _lastLogTime = DateTime.MaxValue;

        public ConsoleLogger(bool doConsolePrint=true)
        {
            _doConsolePrint = doConsolePrint;
        }

        public void Init( bool filePrint, string logFileName = "", string fileNamePrefix = "")
        {
            _doFilePrint = filePrint;
            if (_doFilePrint)
            {
                _fileNamePrefix = fileNamePrefix;
                _logFileName = logFileName;
                _logFileName = GetFileName();
                InitStreamWriter();
            }
            else
            {

            }
        }

        public void SetLogo(string logo)
        {
            _logo = logo;
        }

        public void SetPriority(int type =4)
        {
            _curPriority =type;
        }

        private string GetFileName()
        {
            string path = _logDir + DateTime.Now.ToString("yyyy_MM_dd") + "/";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception e)
            {
                Log.Write("could not create directory for log.{0}",e.ToString());
            }

            string dt = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            return path + _fileNamePrefix + "_" + dt + ".txt.now";
        }

        public override void Close()
        {
            try
            {
                Log.Write("this session was logged to"+_logFileName);
                LogFileClose();
                _tw = null;
            }
            catch (Exception e)
            {
                Log.Write("log close got an error.{0}", e.ToString());
            }
        }

        private void DoLog(LogType type, string log)
        {
            if ((int)type > _curPriority && type != LogType.DEBUG)//类型大于优先级 并且 不是DEBUG的 过滤掉
            {
                return;
            }
            string info = FormatLogString(type, log);
            WriteLog(info, GetConsoleColor(type));
        }

        private string FormatLogString(LogType type, string log)
        {
            _now = DateTime.Now;
            string info = string.Format("{0} {1}[{2}]{3}", _now.ToString("yyyy-MM-dd HH:mm:ss.fff"), _logo, type, log);
            return info;
        }

        private void WriteLog(string info, ConsoleColor color)
        {
            if (_doConsolePrint)
            {
                WriteConsole(info, color);
            }
            if (_doFilePrint)
            {
                WriteFile(info);
                CheckFileSize(info.Length);
            }
        }

        private void WriteConsole(string info, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void WriteFile(string info)
        {
            _tw.WriteLineAsync();
        }

        private void CheckFileSize(int length)
        {
            bool bNeedCreate = false;
            writeLength +=length;
            flushLength += length;
            if (flushLength>=1024)
            {
                _tw.Flush();
                flushLength = 0;
            }
            if (writeLength> _logFileMaxSize)
            {
                bNeedCreate = true;
            }
            if (_lastLogTime != DateTime.MaxValue && _lastLogTime.Date!= _now.Date)
            {
                bNeedCreate = true;
            }
            _lastLogTime = _now;
            if (bNeedCreate)
            {
                LogFileClose();

                _logFileName = GetFileName();

                //
                InitStreamWriter();
            }
        }

        private void InitStreamWriter()
        {
            _tw = new StreamWriter(_logFileName);
            _tw.AutoFlush = false;
            writeLength = 0;
            flushLength = 0;
        }

        private void LogFileClose()
        {
            _tw.Close();
            string closeFileName = _logFileName.Replace(".now", "");
            try
            {
                File.Move(_logFileName, closeFileName);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
            }
        }

        public ConsoleColor GetConsoleColor(LogType type)
        {
            ConsoleColor color = ConsoleColor.Gray;
            switch (type)
            {
                case LogType.WRITE:
                    break;
                case LogType.ERROR:
                    color = ConsoleColor.Red;
                    break;
                case LogType.WARN:
                    color = ConsoleColor.Yellow;
                    break;
                case LogType.INFO:
                    color = ConsoleColor.Green;
                    break;
                case LogType.DEBUG:
                    color = ConsoleColor.Blue;
                    break;
                default:
                    break;
            }
            return color;
        }


        public override void Debug(string log)
        {
#if DEBUG
            try
            {
                DoLog(LogType.DEBUG, log);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
            }
#endif
        }

        public override void Error(string log)
        {
            try
            {
                DoLog(LogType.ERROR, log);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
            }
        }

        public override void Info(string log)
        {
            try
            {
                DoLog(LogType.INFO, log);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
            }
        }

        public override void Warn(string log)
        {
            try
            {
                DoLog(LogType.WARN, log);
            }
            catch (Exception e)
            {
                Log.Write(e.ToString());
            }
        }

        public override void Write(string log)
        {
            try
            {
                string info = FormatLogString(LogType.WRITE, log);
                Console.WriteLine(info);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
