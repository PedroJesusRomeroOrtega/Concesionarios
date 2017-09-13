using Concesionarios.Core;
using Concesionarios.Service;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Concesionarios.WebApi.Controllers
{
    public class ConcesionarioController : ApiController
    {
        readonly IConcesionarioService concesionarioService;
        public ConcesionarioController(IConcesionarioService concesionarioService)
        {
            this.concesionarioService = concesionarioService;
        }

        // GET: api/Concesionario
        public IEnumerable<Concesionario> Get()
        {
            //TODO:quitar concesionariomodel y marcamodel
            //return concesionarioService.GetAll().Select(c => new ConcesionarioModel()
            //{
            //    Nombre = c.Nombre,
            //    Direccion = c.Direccion
            //});
            return concesionarioService.GetAll();
        }

        // GET: api/Concesionario/5
        [ResponseType(typeof(Concesionario))]
        public IHttpActionResult Get(int id)
        {
            var concesionario = concesionarioService.GetById(id);
            if (concesionario == null) return NotFound();
            else return Ok(concesionario);
        }

        // POST: api/Concesionario
        [ResponseType(typeof(Concesionario))]
        public IHttpActionResult Post([FromBody]Concesionario concesionario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            concesionarioService.Insert(concesionario);
            return CreatedAtRoute("DefaultApi", new { id = concesionario.Id }, concesionario);
        }

        // PUT: api/Concesionario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]Concesionario concesionario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != concesionario.Id) return BadRequest();
            else
            {
                concesionarioService.Update(concesionario);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        //DELETE: api/Concesionario/5
        [ResponseType(typeof(Concesionario))]
        public IHttpActionResult Delete(int id)
        {
            var concesionario = concesionarioService.GetById(id);
            if (concesionario == null) return NotFound();
            else
            {
                concesionarioService.Delete(concesionario);
                return Ok(concesionario);
            }
        }
    }
}
