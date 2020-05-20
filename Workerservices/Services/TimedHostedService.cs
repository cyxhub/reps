using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workerservices.Services
{
    class TimedHostedService : IHostedService, IDisposable
    {
        private ILogger<TimedHostedService> _logger;

        public void Dispose()
        {
            _logger.LogInformation("dispose 了");
        }
        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("worker开始了");
            for(int i = 0; i < 10; i++)
            {
                _logger.LogInformation("->"+i*i);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("停止了");
            return Task.CompletedTask;
        }
    }
}
