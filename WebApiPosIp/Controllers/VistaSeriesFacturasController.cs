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
    public class VistaSeriesFacturasController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/VistaSeriesFacturas
        public IQueryable<Series> GetVistaSeriesFacturas()
        {
            return db.Series;
        }

        // GET: api/VistaSeriesFacturas/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult GetVistaSeriesFacturas(short id)
        {
            Series vistaSeriesFacturas = db.Series.Find(id);
            if (vistaSeriesFacturas == null)
            {
                return NotFound();
            }

            return Ok(vistaSeriesFacturas);
        }

        // PUT: api/VistaSeriesFacturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVistaSeriesFacturas(short id, Series vistaSeriesFacturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vistaSeriesFacturas.idSerie)
            {
                return BadRequest();
            }

            db.Entry(vistaSeriesFacturas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VistaSeriesFacturasExists(id))
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

        // POST: api/VistaSeriesFacturas
        [ResponseType(typeof(Series))]
        public IHttpActionResult PostVistaSeriesFacturas(Series vistaSeriesFacturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Series.Add(vistaSeriesFacturas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VistaSeriesFacturasExists(vistaSeriesFacturas.idSerie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vistaSeriesFacturas.idSerie }, vistaSeriesFacturas);
        }

        // DELETE: api/VistaSeriesFacturas/5
        [ResponseType(typeof(Series))]
        public IHttpActionResult DeleteVistaSeriesFacturas(short id)
        {
            Series vistaSeriesFacturas = db.Series.Find(id);
            if (vistaSeriesFacturas == null)
            {
                return NotFound();
            }

            db.Series.Remove(vistaSeriesFacturas);
            db.SaveChanges();

            return Ok(vistaSeriesFacturas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VistaSeriesFacturasExists(short id)
        {
            return db.Series.Count(e => e.idSerie == id) > 0;
        }
    }
}