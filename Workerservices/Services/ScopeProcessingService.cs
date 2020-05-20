using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workerservices.Services
{
    class ScopeProcessingService
    {
        private int count = 0;
        private ILogger<ScopeProcessingService> _logger;

        public ScopeProcessingService(ILogger<ScopeProcessingService> logger)
        {
            _logger = logger;
        }
        public async Task Dowork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("scoped service开始了，count:{count}",count++);
                await Task.Delay(1000,cancellationToken);
            }
        }
    }

    /**
     * 消耗dowork
     */
     public class CusumeScopedHostedService : BackgroundService
    {
        private IServiceProvider _services;
        private ILogger<CusumeScopedHostedService> _logger;

        public CusumeScopedHostedService(IServiceProvider serviceProvider,ILogger<CusumeScopedHostedService> logger)
        {
            _services = serviceProvider;
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("worker开始了");
            return Task.CompletedTask;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("worker进程处理了");
            await doWork(stoppingToken);
        }
        private async Task doWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation("工作进程");
            using (var scope= _services.CreateScope())
            {
                var scopedprocessingService = scope.ServiceProvider.GetRequiredService<ScopeProcessingService>();
                await scopedprocessingService.Dowork(cancellationToken);
            }
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("worker进程结束了");
            return Task.CompletedTask;
        }
    }
}
