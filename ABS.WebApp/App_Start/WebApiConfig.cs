using System.Web.Http;

namespace ABS.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "BridgeApi",
                routeTemplate: "api/mybridge/getexcel",
                defaults: new { }
            );
        }
    }
}
