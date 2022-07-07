using System;
using System.Linq;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders) 
            =>this.Appenders = appenders;

        public IAppender[] Appenders { get; }

        public void TryToAppendLog(ReportLevel reportLevel, string dateTime, string message)
        {
            foreach (IAppender appender in Appenders)
            {
                if (reportLevel >= appender.ReportLevel)
                {
                    appender.Append(dateTime, reportLevel, message);
                    appender.Count++;
                }
            }
        }
    }
}
