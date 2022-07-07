using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Loggers

{
    public interface ILogger 
    {
        IAppender[] Appenders { get; }

        void TryToAppendLog(ReportLevel reportLevel, string dateTime, string message); 
    }
}
