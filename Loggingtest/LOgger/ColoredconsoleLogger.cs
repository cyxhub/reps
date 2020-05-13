using Loggingtest.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loggingtest.LOgger
{
    public class ColoredconsoleLogger : ILogger
    {
        private string _name;
        private ColoredConsoleLoggerConfiguration _config;

        public ColoredconsoleLogger(string name,ColoredConsoleLoggerConfiguration configuration)
        {
            _name = name;
            _config = configuration;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            var color = Console.ForegroundColor;
            Console.ForegroundColor = _config.color;
            Console.ForegroundColor = color;
        }
    }
}
