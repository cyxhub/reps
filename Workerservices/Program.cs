using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Workerservices.Services;

namespace Workerservices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //开始的第一个
                    //services.AddHostedService<Worker>();
                    //计时
                    services.AddHostedService<TimedHostedService>();
                    //consume scoped
                    /*services.AddHostedService<CusumeScopedHostedService>();
                    services.AddScoped<ScopeProcessingService>();*/
                });
    }
}
