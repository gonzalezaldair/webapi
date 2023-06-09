using System.Collections.Immutable;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware (RequestDelegate nextRequestDelegate)
        {
            next = nextRequestDelegate;
        }

        public async Task Invoke( Microsoft.AspNetCore.Http.HttpContext context)
        {

            await next(context);
            
            if(context.Request.Query.Any( p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }

        }
    }

    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}