using Concesionarios.Core;
using Concesionarios.Service;
using Concesionarios.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Concesionarios.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:62726", headers: "*", methods: "*")]
    public class CocheController : ApiController
    {
        ICocheService cocheService;
        public CocheController(ICocheService cocheService)
        {
            this.cocheService = cocheService;
        }

        //GET: api/Coche
        public IEnumerable<CocheViewModel> Get()
        {
            IEnumerable<Coche> coches = cocheService.GetAll();
            return coches.Select(c => new CocheViewModel()
            {
                Id = c.Id,
                Matricula = c.Matricula,
                Kilometros = c.Kilometros,
                IdConcesionario = c.IdConcesionario,
                IdMarca = c.IdMarca
            });
        }

        //GET: api/Coche/CocheDelConcesionario/1
        [Route("api/Coche/CocheDelConcesionario/{idConcesionario}")]
        public IEnumerable<CocheViewModel> GetDelConcesionario(int idConcesionario)
        {
            return cocheService.GetAll(idConcesionario).Select(c => new CocheViewModel()
            {
                Id = c.Id,
                Matricula = c.Matricula,
                Kilometros = c.Kilometros,
                IdConcesionario = c.IdConcesionario,
                IdMarca = c.IdMarca
            });
        }

        //GET: api/Coche/1
        [ResponseType(typeof(CocheViewModel))]
        public IHttpActionResult Get(int id)
        {
            var coche = cocheService.GetById(id);
            if (coche == null) return NotFound();
            else return Ok(new CocheViewModel()
            {
                Id = coche.Id,
                Matricula = coche.Matricula,
                Kilometros = coche.Kilometros,
                IdConcesionario = coche.IdConcesionario,
                IdMarca = coche.IdMarca
            });
        }

        // POST: api/Coche
        [ResponseType(typeof(CocheViewModel))]
        public IHttpActionResult Post([FromBody]CocheViewModel cocheVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            cocheService.Insert(new Coche()
            {
                Id = cocheVM.Id,
                Matricula = cocheVM.Matricula,
                Kilometros = cocheVM.Kilometros,
                IdConcesionario = cocheVM.IdConcesionario,
                IdMarca = cocheVM.IdMarca
            });
            return CreatedAtRoute("DefaultApi", new { id = cocheVM.Id }, cocheVM);
        }

        // PUT: api/Coche/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]CocheViewModel cocheVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != cocheVM.Id) return BadRequest();
            else
            {
                cocheService.Update(new Coche()
                {
                    Id = cocheVM.Id,
                    Matricula = cocheVM.Matricula,
                    Kilometros = cocheVM.Kilometros,
                    IdConcesionario = cocheVM.IdConcesionario,
                    IdMarca = cocheVM.IdMarca
                });
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        //DELETE: api/Coche/5
        [ResponseType(typeof(CocheViewModel))]
        public IHttpActionResult Delete(int id)
        {
            var coche = cocheService.GetById(id);
            if (coche == null) return NotFound();
            else
            {
                cocheService.Delete(coche);
                return Ok(new CocheViewModel()
                {
                    Id = coche.Id,
                    Matricula = coche.Matricula,
                    Kilometros = coche.Kilometros,
                    IdConcesionario = coche.IdConcesionario,
                    IdMarca = coche.IdMarca
                });
            }
        }

    }
}
