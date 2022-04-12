using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.CrawlerFiles
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

        public static void Log(LogLevel level, string message, [CallerMemberName] string memberName = "")
        {
            if(!level.HasFlag(LogLevel.INFO))
            {
                DataAccess.SaveLog(LogLevel.INFO, message, memberName);
            }
            _logQueue.Enqueue($"{memberName}:{level}:{message}");
        }

        public static bool TryGetLog(out string? log) => _logQueue.TryDequeue(out log);
    }
}
