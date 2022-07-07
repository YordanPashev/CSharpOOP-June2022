using SolidExerciseLogger.Appenders;

namespace SolidExerciseLogger.Loggers

{
    public interface ILogger 
    {
        IAppender[] Appenders { get; }

        void Info(string message);

        void Error(string message);

        void Warning(string message);

        void Critical(string message);

        void Fatal(string message); 
    }
}
