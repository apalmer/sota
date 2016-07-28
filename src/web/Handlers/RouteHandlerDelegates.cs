using web.Configuration;
using web.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Handlers
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
                case "resolve":
                    return Resolve(context);
                    break;
                case "":
                default:
                    return context.Response.WriteAsync($"Track handler handling... {string.Join(", ", routeValues)}");
                    break;
            }
        }

        public Task Create(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            return context.Response.WriteAsync($"Create handler handling... {string.Join(", ", routeValues)}");
        }

        public Task Detonate(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            return context.Response.WriteAsync($"Detonate handler handling... {string.Join(", ", routeValues)}");throw new NotImplementedException();
        }

        public Task Resolve(HttpContext context)
        {
            var routeValues = context.GetRouteData().Values;
            IAggregateRoot root = context.RequestServices.GetService(typeof(IAggregateRoot)) as IAggregateRoot;

            var session = context.Session;
            if(session.GetString("something") == default(string)) 
            {
                session.SetString("something", "this is really something");
            }

            var results = root.GetResponse(routeValues);

            return context.Response.WriteAsync(results);
        }
    }
}
