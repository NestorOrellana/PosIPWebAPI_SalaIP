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
    [RoutePrefix("Traslado")]
    public class TrasladoFacturasController : ApiController
    {
        private readonly ITrasladoFacturas _servicioTrasladoF;

        #region Constructor
        public TrasladoFacturasController(ITrasladoFacturas servicioTrasladoF)
        {
            _servicioTrasladoF = servicioTrasladoF;
        }
        #endregion

        #region Servicios
        /// <summary>
        /// Servicio que ejecuta el SP para traslado de facturas registradas de una sucursal especifica a la intermedia.
        /// </summary>
        /// <param name="fecha">Fecha de las facturas a trasladar</param>
        /// <param name="idSucursal">Id de la sucursal que realizara el traslado</param>
        /// <param name="usuario">Usuario que ejecuto el SP</param>
        /// <returns></returns>
        [EnableQuery]
        [Route("TrasladoFacturas")]
        public HttpResponseMessage TrasladoFacturas(DateTime fecha, int idSucursal, string usuario)
        {
            var traslado = _servicioTrasladoF.TrasladoFacturas(fecha, idSucursal, usuario);
            var resultado = Request.CreateResponse(HttpStatusCode.OK, traslado);
            return resultado;
        }
        #endregion
    }
}
