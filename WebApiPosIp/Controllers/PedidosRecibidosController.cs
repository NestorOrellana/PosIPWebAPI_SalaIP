using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using BusinessEntities;
using DataModel;

namespace WebApiPosIp.Controllers
{
    public class PedidosRecibidosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/PedidosRecibidos
        public IQueryable<PedidosRecibidos> GetPedidosRecibidos()
        {
            return db.PedidosRecibidos;
        }

        [EnableQuery]
        [Route("RegistroPedidoConfirmado")]
        [ResponseType(typeof(PedidosRecibidosEnt))]
        public IHttpActionResult RegistrarPedidoConfirmado(ObservableCollection<PedidosRecibidosEnt> detallesPedido)
        {
            ObservableCollection<PedidosRecibidos> itemsMappedList = new ObservableCollection<PedidosRecibidos>();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var detallePedido in detallesPedido)
            {
                var mappedItem = new PedidosRecibidos()
                {
                    IdSucursal = detallePedido.IdSucursal,
                    IdProducto = detallePedido.IdProducto,
                    FechaEntrega = detallePedido.FechaEntrega,
                    CantidadEnviada = detallePedido.CantidadEnviada,
                    CantidadConfirmada = detallePedido.CantidadConfirmada,
                    Estado = detallePedido.Estado,
                    IdPedido = detallePedido.IdPedido,
                    FechaHoraAprobacion = detallePedido.FechaHoraAprobacion
                };

                itemsMappedList.Add(mappedItem);
            }

            db.PedidosRecibidos.AddRange(itemsMappedList);

            try
            {
                db.SaveChanges();
            }
            catch(Exception)
            {
                var problema = Conflict();

                return problema;
            }

            return Ok();
        }

        #region Acciones comentadas
        // GET: api/PedidosRecibidos/5
        //[ResponseType(typeof(PedidosRecibidos))]
        //public IHttpActionResult GetPedidosRecibidos(long id)
        //{
        //    PedidosRecibidos pedidosRecibidos = db.PedidosRecibidos.Find(id);
        //    if (pedidosRecibidos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(pedidosRecibidos);
        //}

        // PUT: api/PedidosRecibidos/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPedidosRecibidos(long id, PedidosRecibidos pedidosRecibidos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != pedidosRecibidos.IdRegistro)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(pedidosRecibidos).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PedidosRecibidosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PedidosRecibidos
        //[ResponseType(typeof(PedidosRecibidos))]
        //public IHttpActionResult PostPedidosRecibidos(PedidosRecibidos pedidosRecibidos)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PedidosRecibidos.Add(pedidosRecibidos);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = pedidosRecibidos.IdRegistro }, pedidosRecibidos);
        //}

        // DELETE: api/PedidosRecibidos/5
        //[ResponseType(typeof(PedidosRecibidos))]
        //public IHttpActionResult DeletePedidosRecibidos(long id)
        //{
        //    PedidosRecibidos pedidosRecibidos = db.PedidosRecibidos.Find(id);
        //    if (pedidosRecibidos == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PedidosRecibidos.Remove(pedidosRecibidos);
        //    db.SaveChanges();

        //    return Ok(pedidosRecibidos);
        //}
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidosRecibidosExists(long id)
        {
            return db.PedidosRecibidos.Count(e => e.IdRegistro == id) > 0;
        }
    }
}