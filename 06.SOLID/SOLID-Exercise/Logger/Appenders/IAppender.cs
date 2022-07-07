using System;
using SolidExerciseLogger.ReportLevels;
using SolidExerciseLogger.Layouts;

namespace SolidExerciseLogger.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessagesCount { get; set; }

        void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
