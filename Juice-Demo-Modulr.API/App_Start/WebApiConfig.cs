using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //To write JSON property names with camel casing, without changing data model.
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            json.SerializerSettings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
