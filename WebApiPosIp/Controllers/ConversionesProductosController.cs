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
    public class ConversionesProductosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/ConversionesProductos
        public IQueryable<ConversionesProductos> GetConversionesProductos()
        {
            var result = db.ConversionesProductos;
            return result;
        }

        // GET: api/ConversionesProductos/5
        [ResponseType(typeof(ConversionesProductos))]
        public IHttpActionResult GetConversionesProductos(int id)
        {
            ConversionesProductos conversionesProductos = db.ConversionesProductos.Find(id);
            if (conversionesProductos == null)
            {
                return NotFound();
            }

            return Ok(conversionesProductos);
        }

        // PUT: api/ConversionesProductos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConversionesProductos(int id, ConversionesProductos conversionesProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conversionesProductos.IdConversion)
            {
                return BadRequest();
            }

            db.Entry(conversionesProductos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversionesProductosExists(id))
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

        // POST: api/ConversionesProductos
        [ResponseType(typeof(ConversionesProductos))]
        public IHttpActionResult PostConversionesProductos(ConversionesProductos conversionesProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConversionesProductos.Add(conversionesProductos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conversionesProductos.IdConversion }, conversionesProductos);
        }

        // DELETE: api/ConversionesProductos/5
        [ResponseType(typeof(ConversionesProductos))]
        public IHttpActionResult DeleteConversionesProductos(int id)
        {
            ConversionesProductos conversionesProductos = db.ConversionesProductos.Find(id);
            if (conversionesProductos == null)
            {
                return NotFound();
            }

            db.ConversionesProductos.Remove(conversionesProductos);
            db.SaveChanges();

            return Ok(conversionesProductos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConversionesProductosExists(int id)
        {
            return db.ConversionesProductos.Count(e => e.IdConversion == id) > 0;
        }
    }
}