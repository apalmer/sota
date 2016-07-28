using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using web.Extensions;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using web.Configuration;
using Microsoft.Extensions.Configuration;
using web.Domain;

namespace web
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

        public void Configure(IApplicationBuilder web, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            web.UseSession();

            if (env.IsDevelopment())
            {
                web.UseDeveloperExceptionPage();
            }
             
            web.UseCustomStaticFiles();

            web.UseCustomLogger(loggerFactory);

            web.UseSession();

            web.UseCustomRoutes(web.ApplicationServices.GetService<IAggregateRoot>());

            web.UseCustomMiddleware();

            web.Run(async (context) => 
            {
                await context.Response.WriteAsync("\nResponse completed completed");
            });
        }
    }
}
