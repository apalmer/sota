using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
using app.Extensions;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace app
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            //services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomStaticFiles();
            

            app.UseCustomMiddleware();

            //var routeHandler = new RouteHandler(context => {

            //    var routeValues = context.GetRouteData().Values;

            //    return context.Response.WriteAsync(
            //        $" Hello! Route values: { string.Join(",", routeValues)}");  
            //});

            //var routeBuilder = new RouteBuilder(app, routeHandler);

            //routeBuilder.MapRoute("default Route", "something/{mode:regex(alpha|beta|gamma)}/{id:int}");

            //var routes = routeBuilder.Build();
            //app.UseRouter(routes);

            //app.Run(async (context)=> {
            //    await context.Response.WriteAsync("written from middleware");
            //});

        }
    }
}
