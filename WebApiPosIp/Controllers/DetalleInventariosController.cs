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
    [RoutePrefix("DetallesDeInventario")]
    public class DetalleInventariosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        [Route("TodosLosDetalles")]
        public IQueryable<DetalleInventario> GetDetalleInventario()
        {
            return db.DetalleInventario;
        }

        [Route("TodosLosDetallesPorRegistro")]
        public IQueryable<DetalleInventario> GetDetalleInventario(int IdRegistro)
        {
            return db.DetalleInventario.Where(d => d.IdRegistro == IdRegistro);
        }

        // PUT: api/DetalleInventarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetalleInventario(int id, DetalleInventario detalleInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalleInventario.IdDetalle)
            {
                return BadRequest();
            }

            db.Entry(detalleInventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInventarioExists(id))
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

        // POST: api/DetalleInventarios
        [ResponseType(typeof(DetalleInventario))]
        public IHttpActionResult PostDetalleInventario(DetalleInventario detalleInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetalleInventario.Add(detalleInventario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalleInventario.IdDetalle }, detalleInventario);
        }

        // DELETE: api/DetalleInventarios/5
        [ResponseType(typeof(DetalleInventario))]
        public IHttpActionResult DeleteDetalleInventario(int id)
        {
            DetalleInventario detalleInventario = db.DetalleInventario.Find(id);
            if (detalleInventario == null)
            {
                return NotFound();
            }

            db.DetalleInventario.Remove(detalleInventario);
            db.SaveChanges();

            return Ok(detalleInventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetalleInventarioExists(int id)
        {
            return db.DetalleInventario.Count(e => e.IdDetalle == id) > 0;
        }
    }
}