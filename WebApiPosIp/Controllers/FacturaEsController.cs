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
using System.Web.Http.OData;
using DataModel;

namespace WebApiPosIp.Controllers
{
    public class FacturaEsController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/FacturaEs
        [Route("TodoslosEncabezados")]
        public IQueryable<FacturaE> GetFacturaE()
        {
            return db.FacturaE;
        }

        //Facturas del dia
        [Route("FacturasDelDia")]
        public IQueryable<FacturaE> GetFacturasDD(int IdSucursal)
        {
            DateTime hoy = DateTime.Today;
            DateTime man = DateTime.Today.AddDays(1);

            try
            {
                var result = db.FacturaE.Where(x => x.FechaHora >= hoy).Where(x => x.FechaHora < man).Where(x => x.IdSucursal == IdSucursal);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        // GET: api/FacturaEs/5
        [Route("GetEncabezado")]
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult GetFacturaE(string correlativo, string serie)
        {
            FacturaE facturaE = db.FacturaE.Find(correlativo, serie);
            if (facturaE == null)
            {
                return NotFound();
            }

            return Ok(facturaE);
        }

        // PUT: api/FacturaEs/5
        [EnableQuery]
        [Route("ModificarFactura")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFacturaE(List<FacturaE> ListfacturaE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                foreach (var factura in ListfacturaE)
                {
                    if (!FacturaEExists(factura.Correlativo, factura.NumeroSerie))
                        throw new Exception();

                    //factura.EstadoSinc = 1;

                    db.Entry(factura).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
            catch(Exception)
            {
                    return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FacturaEs
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult PostFacturaE(FacturaE facturaE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<FacturaE> lista = new List<FacturaE>();

            db.FacturaE.AddRange(lista);
            db.FacturaE.Add(facturaE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FacturaEExists(facturaE.Correlativo, facturaE.NumeroSerie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = facturaE.Correlativo, facturaE.NumeroSerie }, facturaE);
        }

        //POST: Insersion de nueva factura con detalles y el detalle de cada combo adquirido.
        [EnableQuery]
        [Route("NuevaFactura")]//ruta especificada para el webapi
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult PostFacturaE(List<FacturaE> listFacturaE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FacturaE.AddRange(listFacturaE);
            //db.FacturaE.Add(facturaE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //if (FacturaEExists(facturaE.Correlativo, facturaE.NumeroSerie))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}d

                var problema = Conflict();

                return problema;
            }

            //var ruta = CreatedAtRoute("DefaultApi", new { }, listFacturaE);

            return Ok();
        }

        // DELETE: api/FacturaEs/5
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult DeleteFacturaE(string Correlativo, string Serie)
        {
            FacturaE facturaE = db.FacturaE.Find(Correlativo, Serie);
            if (facturaE == null)
            {
                return NotFound();
            }

            db.FacturaE.Remove(facturaE);
            db.SaveChanges();

            return Ok(facturaE);
        }

        //Delete FacturasDelDia
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult DeleteFacturaOD(int IdSucursal)
        {
            DateTime hoy = DateTime.Today;
            DateTime man = DateTime.Today.AddDays(1);
            var listaFacturas = db.FacturaE.Where(x => x.FechaHora >= hoy).Where(x => x.FechaHora < man).Where(x => x.IdSucursal == IdSucursal).ToList();
            foreach (var factura in listaFacturas)
            {
                db.FacturaE.Remove(factura);
                db.SaveChanges();

            }
            return Ok();
        }

        /// <summary>
        /// Elimina las facturas de una sucursal el base a la ultima sincronizacion de facturas que se realizo
        /// </summary>
        [EnableQuery]
        [Route("ClearFacturas")]
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult ClearFactura(int IdSucursal, string lastSinc)
        {
            if (lastSinc != null && lastSinc != "")
            {
                var ultimaSincronizacion = DateTime.Parse(lastSinc);
                DateTime diaSiguiente = ultimaSincronizacion.AddDays(1);
                List<FacturaE> listaFacturas = db.FacturaE.Where(f => f.FechaHora > ultimaSincronizacion)
                    .Where(f => f.FechaHora < diaSiguiente)
                    .Where(f => f.IdSucursal == IdSucursal)
                    .ToList();

                db.FacturaE.RemoveRange(listaFacturas);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return Conflict();
                }

                return Ok();

            }
            else
                return Conflict();
        }

        /// <summary>
        /// Elimina las facturas del dia anterior al actual en una sucursal
        /// </summary>
        /// <param name="IdSucursal"></param>
        /// <returns></returns>
        [EnableQuery]
        [Route("RemoverFacturasDiaAnt")]//ruta especificada para el webapi
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult DeleteFacturaDA(int IdSucursal)
        {
            DateTime hoy = DateTime.Today;
            DateTime ayer = DateTime.Today.AddDays(-1);

            var listaFacturas = db.FacturaE.Where(f => f.FechaHora < hoy).Where(f => f.FechaHora >= ayer).Where(f => f.IdSucursal == IdSucursal).ToList();
            db.FacturaE.RemoveRange(listaFacturas);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Conflict();
            }

            return Ok();
        }

        [EnableQuery]
        [Route("RegistroPagoPendienteTarjeta")]
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult RegistrarPagoPendienteTarjeta(FacturaE factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var facturaUpdate = db.FacturaE.Where(x => x.Correlativo == factura.Correlativo).Where(x => x.NumeroSerie == factura.NumeroSerie).Where(x => x.IdSucursal == factura.IdSucursal).FirstOrDefault();
                if (facturaUpdate != null)
                {
                    facturaUpdate.NumeroAutorizacion = factura.NumeroAutorizacion;
                    db.Entry(facturaUpdate).State = EntityState.Modified;

                    db.SaveChanges();
                }
                else
                    throw new Exception("No se encontro la factura" +
                        "");

                //factura.EstadoSinc = 1;

            }
            catch (Exception)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [EnableQuery]
        [Route("ValidarFacturasAnuladas")]
        [ResponseType(typeof(FacturaE))]
        public IHttpActionResult ConfirmarFacturasAnuladas(List<FacturaE> listaFacturasAnuladas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                foreach (var factura in listaFacturasAnuladas)
                {
                    var facturaUpdate = db.FacturaE.Where(x => x.Correlativo == factura.Correlativo).Where(x => x.NumeroSerie == factura.NumeroSerie).Where(x => x.IdSucursal == factura.IdSucursal).FirstOrDefault();
                    if (facturaUpdate != null)
                    {
                        facturaUpdate.Estado = factura.Estado;
                        facturaUpdate.Anulada = true;
                        db.Entry(facturaUpdate).State = EntityState.Modified;
                    }
                    else
                        throw new Exception("No se encontro la factura");
                }

                db.SaveChanges();
                //factura.EstadoSinc = 1;

            }
            catch (Exception)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacturaEExists(string Correlativo, string Serie)
        {
            return db.FacturaE.Count(e => e.Correlativo == Correlativo && e.NumeroSerie == Serie) > 0;
        }
    }
}