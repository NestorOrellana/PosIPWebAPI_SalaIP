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
    public class PluController : ApiController
    {
        private readonly IPluServices _pluServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de Plu
        /// </summary>
        public PluController(IPluServices pluservices)
        {
            _pluServices = pluservices;
        }

        #endregion

        //-----Controlador que muestra los registros de plu almacenados en la bd-----//
        [EnableQuery]
        [HttpGet]
        [Route("allPlus")]//ruta especificada para el webapi
        public HttpResponseMessage getAllPlu()
        {
            var plu = _pluServices.GetAllPlu();
            if (plu != null)
            {
                var pluList = plu as List<PluEnt> ?? plu.ToList();
                if (pluList.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pluList.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron plus registrados.");
        }

        //-- Controlador que retorna todos los PLU registrados de una Sucursal especifica --//
        [EnableQuery]
        [HttpGet]
        [Route("PLUPorSucursal")]
        public HttpResponseMessage GetPluPorSucursal(int idSucursal)
        {
            var plu = _pluServices.GetPluPorSucursal(idSucursal);
            if(plu != null)
            {
                var pluList = plu as List<PluEnt> ?? plu.ToList();
                if (pluList.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pluList.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron PLU's registrados para la sucursal indicada.");
        }

        //------Controlador que retorna un plu en especifico registrado en la bd-------//
        [EnableQuery]
        [Route("getPlu")]//ruta especifica para el web api
        public HttpResponseMessage Get(int idPlu)
        {
            var plu = _pluServices.GetPluById(idPlu);
            if (plu != null)
                return Request.CreateResponse(HttpStatusCode.OK, plu);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El plu indicado no existe registrado, por favor vuela a intentarlo.");
        }

        //----------Controlador que inserta un nuevo plu en la bd-----------------------//
        [EnableQuery]
        [Route("newPlu")]//Ruta especificada para el webapi
        public string Post([FromBody] PluEnt nuevoPlu)
        {
            return _pluServices.CreatePlu(nuevoPlu);
        }

        //----------Controlador que actualiza un plu registrado en la bd-----------------//
        [EnableQuery]
        [Route("updatePlu")]//Ruta especifica para el webapi
        public string Put(int idPlu, [FromBody]PluEnt upPlu)
        {
            if (idPlu > 0)
            {
                return _pluServices.UpdatePlu(idPlu, upPlu);
            }
            return "Plu modificado exitosamente.";
        }
    }
}
