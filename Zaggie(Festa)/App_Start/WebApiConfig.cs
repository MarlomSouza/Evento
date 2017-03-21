using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Zaggie_Festa_
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "Login",
              routeTemplate: "{controller}/{email}/{senha}"
            );

            config.Routes.MapHttpRoute(
                name: "ObterEventosPorDono",
                routeTemplate: "{controller}/{donoEventoId}"
             );

            config.Routes.MapHttpRoute(
                name: "ObterItemPorEvento",
                routeTemplate: "{controller}/{eventoId}"
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
