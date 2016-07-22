using app.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Handlers
{
    public class RouteHandlerDelegates
    {
        public Task Track(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;

            switch (routeValues["mode"].ToString().ToLower())
            {
                case "detonate":
                    return Detonate(context);
                    break;
                case "":
                default:
                    return context.Response.WriteAsync($"Track handler handling... {string.Join(", ", routeValues)}");
                    break;
            }
        }

        internal Task Create(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            return context.Response.WriteAsync($"Create handler handling... {string.Join(", ", routeValues)}");
        }

        internal Task Detonate(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            return context.Response.WriteAsync($"Detonate handler handling... {string.Join(", ", routeValues)}");throw new NotImplementedException();
        }
    }
}
