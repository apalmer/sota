using app.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace app.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var config = builder.Build();
            services.Configure<CustomOptions>(config);

            //uncomment to use configure via code
            //services.Configure<CustomOptions>(customOptions =>
            //{
            //    customOptions.Alpha = "A1";
            //    customOptions.Beta = "B2";
            //    customOptions.Gamma = "3D";
            //});

            return services;
        }
    }
}
