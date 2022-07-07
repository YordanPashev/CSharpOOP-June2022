using System;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout) { }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string output = string.Format(this.Layout.Format, dateTime, reportLevel, message);
            Console.WriteLine(output);
        }

        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {this.AppendedMessagesCount}";
            
    }
}
