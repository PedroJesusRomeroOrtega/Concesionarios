using Concesionarios.DAL;
using System.Data.Entity;
using System.Web.Http;

namespace Concesionarios.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Database.SetInitializer(new ConcesionariosDBInitializer());//inicializar la tabla con las marcas
        }
    }
}
