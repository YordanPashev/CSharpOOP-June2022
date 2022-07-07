using System;
using System.Linq;
using System.Collections.Generic;
using SolidExerciseLogger.Appenders;
using SolidExerciseLogger.Layouts;
using SolidExerciseLogger.LogFiles;
using SolidExerciseLogger.Loggers;
using SolidExerciseLogger.ReportLevels;

namespace SolidExerciseLogger.Core
{
    public class Engine : IEngine
    {
        private List<IAppender> appenders;

        public Engine()
        {
            appenders = new List<IAppender>();
        }

        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            GetAllAppenders(numberOfAppenders);

            string cmd = string.Empty;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                CreateLog(cmdArgs);
            }

            DisplayLoggerInfo(appenders);
        }

        private void GetAllAppenders(int numberOfAppenders)
        {
            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                ReportLevel reportlevel = GetReportLevel(appenderInfo);

                string appenderType = appenderInfo[0];
                string layOutType = appenderInfo[1];
                IAppender appender = null;

                if (layOutType == "SimpleLayout")
                {
                    appender = CreateAppenderWithSimpleLayout(reportlevel, appenderType);
                }

                else if (layOutType == "XmlLayout")
                {
                    appender = CreateAppenderWithXmlLayout(reportlevel, appenderType);
                }

                appenders.Add(appender);
            }
        }

        private ReportLevel GetReportLevel(string[] appenderInfo)
        {
            if (appenderInfo.Length == 3)
            {
                string reportLevelString = appenderInfo[2];
                return (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelString, true);   
            }

            return ReportLevel.INFO;
        }

        private IAppender CreateAppenderWithXmlLayout(ReportLevel reportLevel, string appenderType)
        {
            ILayout xmlLayout = new XmlLayout();
            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(xmlLayout);
            }

            else if (appenderType == "FileAppender")
            {
                appender = new FileAppender(xmlLayout, new LogFile());
            }

            appender.ReportLevel = reportLevel;
            return appender;
        }

        private IAppender CreateAppenderWithSimpleLayout(ReportLevel reportLevel, string appenderType)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender appender = null;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(simpleLayout);
            }

            else if (appenderType == "FileAppender")
            {
                ILogFile file = new LogFile();
                appender = new FileAppender(simpleLayout, file);
            }

            appender.ReportLevel = reportLevel;
            return appender;
        }

        private void CreateLog(string[] cmdArgs)
        {
            string reportLevelString = cmdArgs[0];
            DateTime dateTime = DateTime.Parse(cmdArgs[1]);
            string message = cmdArgs[2];
            ReportLevel reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelString, true);

            foreach (var appender in appenders)
            {
                ILogger log = new Logger(appender);
               log.TryToAppendMessage(reportLevel, dateTime, message);
            }
        }

        private void DisplayLoggerInfo(List<IAppender> appenders)
        {
            Console.WriteLine("Logger info");

            foreach (var logger in appenders)
            {
                Console.WriteLine(logger);
            }
        }
    }
}
