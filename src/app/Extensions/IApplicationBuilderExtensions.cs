using app.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using app.Handlers;
using app.Domain;

namespace app.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomStaticFiles(this IApplicationBuilder builder)
        {
            //uncomment to use default files
            //builder.UseDefaultFiles();

            builder.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });

            builder.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
                RequestPath = new PathString("/StaticFiles")
            });

            return builder;
        }

        public static IApplicationBuilder UseCustomRoutes(this IApplicationBuilder builder, IAggregateRoot root)
        {
            var handlers = new RouteHandlerDelegates();
            
            var routeBuilder = new RouteBuilder(builder);

            routeBuilder.MapRoute("route/{mode:regex(track|resolve|detonate)}/{id}",handlers.Track);

            routeBuilder.MapRoute("route/{mode:regex(create)}/{id}", handlers.Create);

            var routes = routeBuilder.Build();

            builder.UseRouter(routes);

            return builder;
        }

        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }


        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder builder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            var logSwitch = new SourceSwitch("sourceSwitch", "Logging Test");
            logSwitch.Level = SourceLevels.Warning;
            loggerFactory.AddTraceSource(logSwitch , new TextWriterTraceListener(writer: Console.Out));

            return builder;
        }
    }
}
