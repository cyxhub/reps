using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loggingtest.Controllers;
using Loggingtest.LOgger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Fluent;

namespace Loggingtest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.ConfigureNLog("nlog.config");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            loggerFactory.AddNLog();
           
            /*loggerFactory.AddProvider(new ColoredconsolelogProvider(new ColoredConsoleLoggerConfiguration
            {
                logLevel = LogLevel.Warning,
                color = ConsoleColor.Blue
            }));
            loggerFactory.AddProvider(new ColoredconsolelogProvider(new ColoredConsoleLoggerConfiguration
            {
                logLevel = LogLevel.Debug,
                color = ConsoleColor.Gray
            }));
            loggerFactory.AddProvider(new ColoredconsolelogProvider(new ColoredConsoleLoggerConfiguration
            {
                logLevel = LogLevel.Information,
                color=ConsoleColor.Red
            })) ;*/
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
