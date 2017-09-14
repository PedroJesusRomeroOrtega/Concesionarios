using Concesionarios.Service;
using Concesionarios.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<MarcaViewModel> Get()
        {
            return marcaService.GetAll().Select(m => new MarcaViewModel()
            {
                Id = m.Id,
                Nombre = m.Nombre
            });
        }
    }
}
