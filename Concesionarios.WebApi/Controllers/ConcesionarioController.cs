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
    public class ConcesionarioController : ApiController
    {

        IConcesionarioService concesionarioService;
        public ConcesionarioController(IConcesionarioService concesionarioService)
        {
            this.concesionarioService = concesionarioService;
        }

        //// GET: api/Concesionario
        public IEnumerable<ConcesionarioViewModel> Get()
        {
            return concesionarioService.GetAll().Select(c => new ConcesionarioViewModel()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion
            });
        }

        //GET: api/Concesionario/5
        [ResponseType(typeof(ConcesionarioViewModel))]
        public IHttpActionResult Get(int id)
        {
            var concesionario = concesionarioService.GetById(id);
            if (concesionario == null) return NotFound();
            else return Ok(new ConcesionarioViewModel()
            {
                Id = concesionario.Id,
                Nombre = concesionario.Nombre,
                Direccion = concesionario.Direccion
            });
        }

        // POST: api/Concesionario
        [ResponseType(typeof(ConcesionarioViewModel))]
        public IHttpActionResult Post([FromBody]ConcesionarioViewModel concesionarioVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            concesionarioService.Insert(new Concesionario()
            {
                Id = concesionarioVM.Id,
                Nombre = concesionarioVM.Nombre,
                Direccion = concesionarioVM.Direccion
            });
            return CreatedAtRoute("DefaultApi", new { id = concesionarioVM.Id }, concesionarioVM);
        }

        // PUT: api/Concesionario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]ConcesionarioViewModel concesionarioVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != concesionarioVM.Id) return BadRequest();
            else
            {
                concesionarioService.Update(new Concesionario()
                {
                    Id = concesionarioVM.Id,
                    Nombre = concesionarioVM.Nombre,
                    Direccion = concesionarioVM.Direccion
                });
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        //DELETE: api/Concesionario/5
        [ResponseType(typeof(ConcesionarioViewModel))]
        public IHttpActionResult Delete(int id)
        {
            var concesionario = concesionarioService.GetById(id);
            if (concesionario == null) return NotFound();
            else
            {
                concesionarioService.Delete(concesionario);
                return Ok(new ConcesionarioViewModel()
                {
                    Id = concesionario.Id,
                    Nombre = concesionario.Nombre,
                    Direccion = concesionario.Direccion
                });
            }
        }
    }
}
