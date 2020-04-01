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
    public class WebServicePathsController : ApiController
    {
        private ComercializacionDIPEntities db = new ComercializacionDIPEntities();

        // GET: api/WebServicePaths
        public IQueryable<WebServicePath> GetWebServicePath()
        {
            return db.WebServicePath;
        }

        // GET: api/WebServicePaths/5
        [ResponseType(typeof(WebServicePath))]
        public IHttpActionResult GetWebServicePath(short id)
        {
            WebServicePath webServicePath = db.WebServicePath.Find(id);
            if (webServicePath == null)
            {
                return NotFound();
            }

            return Ok(webServicePath);
        }

        // PUT: api/WebServicePaths/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWebServicePath(short id, WebServicePath webServicePath)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != webServicePath.IdPath)
            {
                return BadRequest();
            }

            db.Entry(webServicePath).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebServicePathExists(id))
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

        // POST: api/WebServicePaths
        [ResponseType(typeof(WebServicePath))]
        public IHttpActionResult PostWebServicePath(WebServicePath webServicePath)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WebServicePath.Add(webServicePath);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = webServicePath.IdPath }, webServicePath);
        }

        // DELETE: api/WebServicePaths/5
        [ResponseType(typeof(WebServicePath))]
        public IHttpActionResult DeleteWebServicePath(short id)
        {
            WebServicePath webServicePath = db.WebServicePath.Find(id);
            if (webServicePath == null)
            {
                return NotFound();
            }

            db.WebServicePath.Remove(webServicePath);
            db.SaveChanges();

            return Ok(webServicePath);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebServicePathExists(short id)
        {
            return db.WebServicePath.Count(e => e.IdPath == id) > 0;
        }
    }
}