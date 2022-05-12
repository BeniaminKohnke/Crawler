using System.Runtime.CompilerServices;

namespace Crawler
{
    public class Logger
    {
        public enum LogLevel
        {
            INFO, 
            WARNING, 
            ERROR, 
            FATAL
        }

        private static readonly Queue<string> _logQueue = new();

        public static void Log(LogLevel level, string message, string configName, Exception? e = null, [CallerMemberName] string memberName = "")
        {
            if(level != LogLevel.INFO)
            {
                var logObject = new LogObject
                {
                    Level = level,
                    Message = message,
                    CallerName = memberName,
                    ConfigName = configName,
                    InternalException = e,
                    LogDate = DateTime.Now,
                };

                DataAccess.SaveLog(logObject);
            }
            _logQueue.Enqueue($"{memberName}:{level}:{message}{(e != null ? $":{e.Message}" : string.Empty)}");
        }

        public static bool TryGetLog(out string? log) => _logQueue.TryDequeue(out log);

        public class LogObject
        {
            public LogLevel Level = LogLevel.WARNING;
            public string Message = string.Empty;
            public string CallerName = string.Empty;
            public string ConfigName = string.Empty;
            public Exception? InternalException = null;
            public DateTime LogDate;
        }
    }
}
