using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddelWarePro.Middelwares
{
    public interface IMyService
    {
        public string parm { get; set; }
    }
    public class MyService : IMyService
    {
        public string parm { get; set; }
    }
    //proxy 
    public class CustomMiddleware
    {
        private RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext,IMyService myService)
        {
            myService.parm = "insect service**---------";
            httpContext.Session.SetString("parm2",myService.parm);
            await _next(httpContext);
        }
    }

    //register dependency service
    public static partial class CustomMiddlewareExtention
    {
        public static IServiceCollection AddMyMiddle(this IServiceCollection serviceDescriptors)
        {
            return serviceDescriptors.AddScoped<IMyService, MyService>();
        }
    }
    //create middleware extensions
    public static partial class CustomMiddlewareExtention
    {
        public static IApplicationBuilder UseMyMiddle(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomMiddleware>();
        }
    }
}
