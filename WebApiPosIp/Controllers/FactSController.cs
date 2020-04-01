using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using System.Web.Http.OData;

namespace WebApiPosIp.Controllers
{
    public class FactSController : ApiController
    {
        private readonly ISFactServices _factServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de Plu
        /// </summary>
        public FactSController(ISFactServices factservices)
        {
            _factServices = factservices;
        }

        #endregion

        //------Controlador que retorna el numero de serie activo de una sucursal indicada registrado en la bd-------//
        [EnableQuery]
        [Route("getActiveSerial")]//ruta especifica para el web api
        public HttpResponseMessage Get(int idSucursal)
        {
            var fact = _factServices.GetFactSBySucursal(idSucursal);
            if (fact != null)
                return Request.CreateResponse(HttpStatusCode.OK, fact);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "La sucursal que indico ya no posee facturas, no puede facturar mas.");
        }

        /// <summary>
        /// Servicio que retorna las series disponibles(activas, e inactivas de una sucursal)
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [Route("SeriesSucursal")]//ruta especificada para el webapi
        public HttpResponseMessage GetSucursalSeries(int idSucursal)
        {
            var series = _factServices.GetSeriesBySucursal(idSucursal);
            if (series != null)
            {
                var serieEnt = series as List<ViewFacturaSerieEnt> ?? series.ToList();
                if (serieEnt.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, serieEnt.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron productos registrados.");
        }

        //----------Controlador que actualiza un plu registrado en la bd-----------------//
        [EnableQuery]
        [Route("updateFactS")]//Ruta especifica para el webapi
        public string Put(short IdSerie, short IdSucursal)
        {
            if (IdSerie > 0 && IdSucursal > 0)
            {
                return _factServices.UpdateFactS(IdSerie, IdSucursal);
            }
            return "Correlativo actualizado exitosamente!";
        }
    }
}
