﻿using NUnit.Framework;
using Unicorn.Core.Logging;

namespace Unicorn.UnitTests.Util
{
    public class TestContextLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            string prefix = level.Equals(LogLevel.Debug) ? $"|\t\t" : string.Empty;
            TestContext.WriteLine($"{prefix}{level}: {message}");
        }
    }
}