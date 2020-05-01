﻿using System;
using Unicorn.Taf.Core.Logging;

namespace Demo.Specifics.Util
{
    public class ConsoleLogger : ILogger
    {
        ////public static ReporterInstance Reporter { get; set; } = null;

        public void Log(LogLevel level, string message)
        {
            string prefix = level.Equals(LogLevel.Debug) || level.Equals(LogLevel.Trace) ? $"\t\t" : string.Empty;
            Console.WriteLine($"{prefix}{level}: {message}");

            ////if (Reporter != null)
            ////{
            ////    Reporter.ReportLoggerMessage(level, message);
            ////}
        }
    }
}
