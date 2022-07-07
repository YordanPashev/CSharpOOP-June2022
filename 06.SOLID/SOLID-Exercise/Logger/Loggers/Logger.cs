using System;
using System.Linq;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Error(string message) { }

        public void Info(string message) { }

        public void Warning(string message)
          => Log(ReportLevel.Warning, message);

        public void Critical(string message)
            => Log(ReportLevel.Critical, message);

         public void Fatal(string message)
            => Log(ReportLevel.Fatal, message);

        private void Log(ReportLevel reportLevel, string message)
        {
            foreach (IAppender appender in Appenders)
            {
                appender.Append(DateTime.Now, reportLevel, message);
            }
        }
    }
}
