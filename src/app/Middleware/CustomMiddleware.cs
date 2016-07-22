using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using app.Configuration;
using Microsoft.Extensions.Options;

namespace app.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private IOptions<CustomOptions> _customOptions;
        
        public CustomMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IOptions<CustomOptions> customOptions)
        {
            _customOptions = customOptions;
            _next = next;
            _logger = loggerFactory.CreateLogger("Custom Logger Endpoint");
        }

        public async Task Invoke(HttpContext context)
        {
            //uncomment below to produce error
            //throw new Exception("Exceptional");

            //uncomment to log at various levels
            //_logger.LogCritical("Using Custom Middleware Critical");
            //_logger.LogDebug("Using Custom Middleware Debug");
            //_logger.LogError("Using Custom Middleware Error");
            //_logger.LogInformation("Using Custom Middleware Info");
            //_logger.LogTrace("Using Custom Middleware Trace");
            //_logger.LogWarning("Using Custom Middleware Warning");
             
            await context.Response.WriteAsync($"CustomMiddleware invoked... Alpha={ _customOptions.Value.Alpha }, Beta={ _customOptions.Value.Beta}, Gamma={ _customOptions.Value.Gamma }");

            await _next.Invoke(context);
        }
    }
}