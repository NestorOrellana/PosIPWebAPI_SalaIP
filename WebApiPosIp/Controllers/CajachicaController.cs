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
    [RoutePrefix("LogIn")]
    public class CajachicaController : ApiController
    {
        private readonly ICajaChicaServices _cajaServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de usuario
        /// </summary>
        public CajachicaController(ICajaChicaServices cajaServices)
        {
            _cajaServices = cajaServices;
        }

        #endregion

        //-------Controlador que retorna el registro de caja chica actualmente activo.
        [EnableQuery]
        [HttpPost]
        [Route("LogActive")]//ruta especificada para el webapi
        public HttpResponseMessage GetCajaActiva()
        {
            var caja = _cajaServices.GetCajaWhere();
            if (caja != null)
                return Request.CreateResponse(HttpStatusCode.OK, caja);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay sesion activa.");
        }

        //------Controlador que registra el login de un usuario en la bd-----//
        [EnableQuery]
        [Route("RegLogin")]//ruta especificada para el webapis
        public int Post([FromBody] CajaChicaEnt nuevaCaja)
        {
            return _cajaServices.CreateCajaChica(nuevaCaja);
        }
    }
}
