using System;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Loggers

{
    public interface ILogger 
    {
        IAppender[] Appenders { get; }

        void TryToAppendMessage(ReportLevel reportLevel, DateTime dateTime, string message); 
    }
}
