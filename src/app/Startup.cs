using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using app.Extensions;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using app.Configuration;
using Microsoft.Extensions.Configuration;
using app.Domain;

namespace app
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddCustomConfiguration();

            services.AddDirectoryBrowser();

            services.AddRouting();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddTransient<IAggregateRoot, AggregateRoot>();

            services.AddTransient<ISubject, Subject>();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             
            app.UseCustomStaticFiles();

            app.UseCustomLogger(loggerFactory);

            app.UseSession();

            app.UseCustomRoutes(app.ApplicationServices.GetService<IAggregateRoot>());

            app.UseCustomMiddleware();

            app.Run(async (context) => 
            {
                await context.Response.WriteAsync("\nResponse completed completed");
            });
        }
    }
}
