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
    [RoutePrefix("Sucursal")]
    public class SucursalController : ApiController
    {
        private readonly ISucursalServices _servicioSucursal;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de usuario
        /// </summary>
        public SucursalController(ISucursalServices servicioSucursal)
        {
            _servicioSucursal = servicioSucursal;
        }

        #endregion

        //-----Controlador que muestra todas las sucursales registradas en la bd-----//
        [EnableQuery]
        [Route("todasSucursales")]//ruta especificada para el webapi
        public HttpResponseMessage Get()
        {
            var sucursales = _servicioSucursal.GetAll();
            if (sucursales != null)
            {
                var entSucursal = sucursales as List<SucursalEnt> ?? sucursales.ToList();
                if (entSucursal.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, entSucursal);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron sucursales registradas");
        }

        //------Controlador que retorna una sucursal basado en su id-------//
        [EnableQuery]
        [Route("SucursalId")]//ruta especificada para el webapi
        public HttpResponseMessage Get(short id)
        {
            var sucursal = _servicioSucursal.GetSucursalById(id);
            if (sucursal != null)
                return Request.CreateResponse(HttpStatusCode.OK, sucursal);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "La sucursal indicada no se encuentra registrada.");
        }

        //------Controlador que inserta un registro de "Sucursal" en la bd-----//
        [EnableQuery]
        [Route("NuevaSucursal")]//ruta especificada para el webapi
        public string Post([FromBody] SucursalEnt nuevaSucursal)
        {
            return _servicioSucursal.CreateSucursal(nuevaSucursal);
        }
    }
}
