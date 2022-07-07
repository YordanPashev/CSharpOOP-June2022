using System;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.Loggers;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.LogFiles;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warning("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
