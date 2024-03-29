﻿using System;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessagesCount { get; set; }

        public abstract void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
