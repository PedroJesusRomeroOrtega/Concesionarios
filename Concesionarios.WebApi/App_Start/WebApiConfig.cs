using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Concesionarios.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(); //para poder llamar a la api desde otro puerto

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

            // Force to ignore Request Content Type Header and reply only JSON
            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());

            //config.Filters.Add(new UnitOfWorkActionFilter());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
