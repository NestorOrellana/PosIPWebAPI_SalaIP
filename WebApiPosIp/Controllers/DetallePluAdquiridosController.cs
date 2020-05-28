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
    public class DetallePluAdquiridosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/DetallePluAdquiridos
        public IQueryable<DetallePluAdquirido> GetDetallePluAdquirido()
        {
            return db.DetallePluAdquirido;
        }

        // GET: api/DetallePluAdquiridos/5
        [ResponseType(typeof(DetallePluAdquirido))]
        public IHttpActionResult GetDetallePluAdquirido(int id)
        {
            DetallePluAdquirido detallePluAdquirido = db.DetallePluAdquirido.Find(id);
            if (detallePluAdquirido == null)
            {
                return NotFound();
            }

            return Ok(detallePluAdquirido);
        }

        // PUT: api/DetallePluAdquiridos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetallePluAdquirido(int id, DetallePluAdquirido detallePluAdquirido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallePluAdquirido.IdDetalle)
            {
                return BadRequest();
            }

            db.Entry(detallePluAdquirido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePluAdquiridoExists(id))
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

        // POST: api/DetallePluAdquiridos
        [ResponseType(typeof(DetallePluAdquirido))]
        public IHttpActionResult PostDetallePluAdquirido(DetallePluAdquirido detallePluAdquirido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DetallePluAdquirido.Add(detallePluAdquirido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detallePluAdquirido.IdDetalle }, detallePluAdquirido);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PostDetallePluAdquirido(string serie, string correlativo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                List<DetalleFactura> listaDetalles = db.DetalleFactura.Where(x => x.NoSerie == serie && x.NoCorrelativo == correlativo).ToList();
                foreach (DetalleFactura detalle in listaDetalles)
                {
                    var plu = db.VistaPLU.Where(x => x.IdPLU == detalle.IdPlu).FirstOrDefault();
                    var receta = db.VistaReceta.Where(x => x.IdReceta == plu.IdReceta).ToList();
                    foreach (VistaReceta item in receta)
                    {
                        DetallePluAdquirido detallePlu = new DetallePluAdquirido()
                        {
                            IdDetalleFactura = detalle.IdDetalle,
                            Cantidad = detalle.Cantidad * Convert.ToDouble(item.cantidad),
                            IdProducto = item.IdProducto,
                            PrecioUnitario = item.precio
                        };

                        db.DetallePluAdquirido.Add(detallePlu);
                    }
                }

                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return Conflict();
            }
        }


        // DELETE: api/DetallePluAdquiridos/5
        [ResponseType(typeof(DetallePluAdquirido))]
        public IHttpActionResult DeleteDetallePluAdquirido(int id)
        {
            DetallePluAdquirido detallePluAdquirido = db.DetallePluAdquirido.Find(id);
            if (detallePluAdquirido == null)
            {
                return NotFound();
            }

            db.DetallePluAdquirido.Remove(detallePluAdquirido);
            db.SaveChanges();

            return Ok(detallePluAdquirido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetallePluAdquiridoExists(int id)
        {
            return db.DetallePluAdquirido.Count(e => e.IdDetalle == id) > 0;
        }
    }
}