using Concesionarios.Core;
using Concesionarios.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace Concesionarios.WebApi.Controllers
{
    public class MarcaController : ApiController
    {
        IMarcaService marcaService;
        public MarcaController(IMarcaService marcaService)
        {
            this.marcaService = marcaService;
        }

        // GET: api/Concesionarios
        public IEnumerable<Marca> Get()
        {
            return marcaService.GetAll();
        }
    }
}
