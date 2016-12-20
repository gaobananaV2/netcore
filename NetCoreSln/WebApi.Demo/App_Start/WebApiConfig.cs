using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi.Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Attribute routing can be combined with convention - based routing.
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
