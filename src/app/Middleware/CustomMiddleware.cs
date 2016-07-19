using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<CustomMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            //throw new Exception("Exceptional");
            //_logger.LogInformation("Using Custom Middleware");
            await context.Response.WriteAsync("CustomMiddleware invoked...");
            //await _next.Invoke(context);
        }
    }
}