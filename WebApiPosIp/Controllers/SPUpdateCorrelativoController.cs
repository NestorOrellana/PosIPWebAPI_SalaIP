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
    [RoutePrefix("Facturacion")]
    public class SPUpdateCorrelativoController : ApiController
    {
        private readonly ISPUpdateCorrelativo _servicioUpCorrelativo;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia del servicio para actualizar un correlativo.
        /// </summary>
        public SPUpdateCorrelativoController(ISPUpdateCorrelativo servicioUpCorelativo)
        {
            _servicioUpCorrelativo = servicioUpCorelativo;
        }

        #endregion

        //-----Controlador que muestra todos los productos registrados en la bd-----//
        [EnableQuery]
        [Route("UpdateCorrelativo")]//ruta especificada para el webapi 
        public HttpResponseMessage UpdateCorrelativo(string numeroSerie, int idSucursal, long correlativo, long numeroDel, long numeroAl, short idSerie)
        {
            var pedido = _servicioUpCorrelativo.UpdateCorrelativo(numeroSerie, idSucursal, correlativo, numeroDel, numeroAl, idSerie);
            return Request.CreateResponse(HttpStatusCode.OK, pedido);
        }
    }
}
