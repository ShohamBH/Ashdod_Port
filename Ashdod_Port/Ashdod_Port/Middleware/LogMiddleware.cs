using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ashdod_Port.Api.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // אתחול ה-TIMER

            await _next(httpContext); // קריאה לפונקציה הבאה ב-Middleware

            stopwatch.Stop(); // עצירת ה-TIMER
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds; // קבלת הזמן שחלף
            var apiName = httpContext.Request.Path; // קבלת שם ה-API
            var dateTime = DateTime.Now; // קבלת תאריך ושעה נוכחיים

            // רישום הזמן, ה-API והתאריך בלוג
            _logger.LogInformation($"[{dateTime}] API: {apiName} took {elapsedMilliseconds} ms");
        }
    }

    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using System.Threading.Tasks;

//namespace Ashdod_Port.Api.Middleware
//{
//    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
//    public class LogMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public LogMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public Task Invoke(HttpContext httpContext)
//        {

//            return _next(httpContext);
//        }
//    }

//    // Extension method used to add the middleware to the HTTP request pipeline.
//    public static class LogMiddlewareExtensions
//    {
//        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<LogMiddleware>();
//        }
//    }
//}
