using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loggingtest.Controllers
{
    public class ColoredConsoleLoggerConfiguration
    {
        public LogLevel logLevel { get; set; } = LogLevel.Warning;
        public ConsoleColor color { get; set; } = ConsoleColor.Yellow;
    }
}
