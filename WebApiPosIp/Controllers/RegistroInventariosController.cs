using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;

namespace WebApiPosIp.Controllers
{
    [RoutePrefix("RegistroDeInventario")]
    public class RegistroInventariosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        [Route("TodosLosRegistros")]
        public IQueryable<RegistroInventario> GetRegistroInventario()
        {
            return db.RegistroInventario;
        }

        // GET: api/RegistroInventarios/5
        [ResponseType(typeof(RegistroInventario))]
        public IHttpActionResult GetRegistroInventario(int id)
        {
            RegistroInventario registroInventario = db.RegistroInventario.Find(id);
            if (registroInventario == null)
            {
                return NotFound();
            }

            return Ok(registroInventario);
        }

        // PUT: api/RegistroInventarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegistroInventario(int id, RegistroInventario registroInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroInventario.IdRegistro)
            {
                return BadRequest();
            }

            db.Entry(registroInventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroInventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RegistroInventarios
        [Route("NuevoRegistroDeInventario")]
        [ResponseType(typeof(RegistroInventario))]
        public IHttpActionResult PostRegistroInventario(RegistroInventario registroInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistroInventario.Add(registroInventario);
            //db.SaveChanges();

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {

                var problema = Conflict();

                return problema;
            }

            return Ok();
        }

        // DELETE: api/RegistroInventarios/5
        [ResponseType(typeof(RegistroInventario))]
        public IHttpActionResult DeleteRegistroInventario(int id)
        {
            RegistroInventario registroInventario = db.RegistroInventario.Find(id);
            if (registroInventario == null)
            {
                return NotFound();
            }

            db.RegistroInventario.Remove(registroInventario);
            db.SaveChanges();

            return Ok(registroInventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroInventarioExists(int id)
        {
            return db.RegistroInventario.Count(e => e.IdRegistro == id) > 0;
        }
    }
}