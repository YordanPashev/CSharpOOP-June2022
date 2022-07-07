using System;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.Loggers;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.LogFiles;
using SolidExerciseLogger.ReportLevels;
using System.Collections.Generic;
using SolidExerciseLogger.Core;

namespace SolidExerciseLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
