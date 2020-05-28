using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddelWarePro
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            /* app.Use(async (context,next)=> {
                 Console.WriteLine("app use +++++++++++");
                 await next.Invoke();
             });
             app.Run(async context=> {
                await context.Response.WriteAsync("this is a basic middle ware") ;
            });*/

            /*app.Map("/map",
                (IApplicationBuilder app2) =>
                {
                    app2.Run(async context =>
                    {
                        await context.Response.WriteAsync("it is from map");
                    });
                }
            );*/

            /*app.MapWhen(context=>context.Request.Query.ContainsKey("branchname"),
                (IApplicationBuilder app2)=> 
                {
                    app2.Run(async context=> {
                    await context.Response.WriteAsync($"the branch is -->"+context.Request.Query["branchname"]);

                });
            });*/

            app.Map("/level",levels=> {
                levels.Map("/levelchild", levelchild =>
                {
                    levelchild.Map("/levels", (IApplicationBuilder app2) =>
                    {
                        app2.Run(async context =>
                        {
                            await context.Response.WriteAsync("/level/levelchild/levels+++++++");
                        });
                    });
                });
                levels.MapWhen(context=>context.Request.Query.ContainsKey("parm"),
                    (IApplicationBuilder app2)=> {
                        app2.Run(async context=> {
                            await context.Response.WriteAsync("it is from /level mapwhen-----"+context.Request.Query["parm"]);
                        });
                    });
            });
        }
        
    }
}
