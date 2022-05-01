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
            if(!level.HasFlag(LogLevel.INFO))
            {
                DataAccess.SaveLog(LogLevel.INFO, message, configName, memberName);
            }
            _logQueue.Enqueue($"{memberName}:{level}:{message}{(e != null ? $":{e.Message}" : string.Empty)}");
        }

        public static bool TryGetLog(out string? log) => _logQueue.TryDequeue(out log);

        public class LogObject
        {
            public Logger.LogLevel Level = Logger.LogLevel.WARNING;
            public string Message = string.Empty;
            public string CallerName = string.Empty;
            public string ConfigName = string.Empty;
            public Exception? InternalException = null;
            public DateTime LogDate;
        }
    }
}
