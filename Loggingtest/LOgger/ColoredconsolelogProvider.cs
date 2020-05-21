using Loggingtest.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loggingtest.LOgger
{
    public class ColoredconsolelogProvider : ILoggerProvider
    {
        private ColoredConsoleLoggerConfiguration _config;

        public ColoredconsolelogProvider(ColoredConsoleLoggerConfiguration config)
        {
            _config = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ColoredconsoleLogger(categoryName,_config);
        }

        public void Dispose()
        {
            Console.WriteLine("dispose -==-");
        }
    }
}
