﻿using System;
using System.IO;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.LogFiles;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile lofFile;

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout) 
            => this.lofFile = logFile;

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string output = string.Format(this.Layout.Format, dateTime, reportLevel, message);

            this.lofFile.Write(output);
            File.AppendAllText("../../../log.txt", output + Environment.NewLine);
        }

        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {this.AppendedMessagesCount}, File size: {this.lofFile.Size}";
    }
}
