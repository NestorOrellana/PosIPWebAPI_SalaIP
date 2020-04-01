using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;

namespace WebApiPosIp.Controllers
{
    public class DetalleFacturasController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/DetalleFacturas
        public IQueryable<DetalleFactura> GetDetalleFactura()
        {
            var result = db.DetalleFactura;
            return result;
        }

        // GET: api/DetalleFacturas/5
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult GetDetalleFactura(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return Ok(detalleFactura);
        }

        // PUT: api/DetalleFacturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetalleFactura(int id, DetalleFactura detalleFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalleFactura.IdDetalle)
            {
                return BadRequest();
            }

            db.Entry(detalleFactura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturaExists(id))
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

        // POST: api/DetalleFacturas
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult PostDetalleFactura(DetalleFactura detalleFactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetalleFactura.Add(detalleFactura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalleFactura.IdDetalle }, detalleFactura);
        }

        // DELETE: api/DetalleFacturas/5
        [ResponseType(typeof(DetalleFactura))]
        public IHttpActionResult DeleteDetalleFactura(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            db.DetalleFactura.Remove(detalleFactura);
            db.SaveChanges();

            return Ok(detalleFactura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetalleFacturaExists(int id)
        {
            return db.DetalleFactura.Count(e => e.IdDetalle == id) > 0;
        }
    }
}