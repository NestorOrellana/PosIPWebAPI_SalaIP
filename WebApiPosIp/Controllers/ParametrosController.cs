using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebApiPosIp.Controllers
{
    [RoutePrefix("Parametros")]
    public class ParametrosController : ApiController
    {
        private readonly IParametroServices _parametroServices;

        public ParametrosController(IParametroServices parametroServices)
        {
            _parametroServices = parametroServices;
        }

        [EnableQuery]
        public HttpResponseMessage GetParametros()
        {
            var parametros = _parametroServices.GetParametros();
            if (parametros != null)
            {
                var listaParametros = parametros as List<ParametrosEnt> ?? parametros.ToList();
                if (listaParametros.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, listaParametros);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron parametros registrados.");
        }
    }
}
