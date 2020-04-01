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
    [RoutePrefix("AjustesDeInventario")]
    public class BitAjusteInventariosController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        [Route("TodosLosAjustes")]
        public IQueryable<BitAjusteInventario> GetBitAjusteInventario()
        {
            return db.BitAjusteInventario;
        }

        // GET: api/BitAjusteInventarios/5
        [ResponseType(typeof(BitAjusteInventario))]
        public IHttpActionResult GetBitAjusteInventario(int id)
        {
            BitAjusteInventario bitAjusteInventario = db.BitAjusteInventario.Find(id);
            if (bitAjusteInventario == null)
            {
                return NotFound();
            }

            return Ok(bitAjusteInventario);
        }

        // PUT: api/BitAjusteInventarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBitAjusteInventario(int id, BitAjusteInventario bitAjusteInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bitAjusteInventario.IdAjuste)
            {
                return BadRequest();
            }

            db.Entry(bitAjusteInventario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitAjusteInventarioExists(id))
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

        // POST: api/BitAjusteInventarios
        [Route("NuevoAjusteDeInventario")]
        [ResponseType(typeof(BitAjusteInventario))]
        public IHttpActionResult PostBitAjusteInventario(BitAjusteInventario bitAjusteInventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BitAjusteInventario.Add(bitAjusteInventario);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                var problema = Conflict();
                return problema;
            }

            return Ok();
        }

        // DELETE: api/BitAjusteInventarios/5
        [ResponseType(typeof(BitAjusteInventario))]
        public IHttpActionResult DeleteBitAjusteInventario(int id)
        {
            BitAjusteInventario bitAjusteInventario = db.BitAjusteInventario.Find(id);
            if (bitAjusteInventario == null)
            {
                return NotFound();
            }

            db.BitAjusteInventario.Remove(bitAjusteInventario);
            db.SaveChanges();

            return Ok(bitAjusteInventario);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BitAjusteInventarioExists(int id)
        {
            return db.BitAjusteInventario.Count(e => e.IdAjuste == id) > 0;
        }
    }
}