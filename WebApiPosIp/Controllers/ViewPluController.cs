using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebApiPosIp.Controllers
{
    public class ViewPluController : ApiController
    {
        private readonly IViewPluServices _pluServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de la vista que retornara los datos del PLU
        /// </summary>
        public ViewPluController(IViewPluServices pluservices)
        {
            _pluServices = pluservices;
        }

        #endregion

        [EnableQuery]
        [HttpGet]
        [Route("TodosLosPLU")]//ruta especificada para el webapi
        public HttpResponseMessage TodosLosPLU()
        {
            var plu = _pluServices.TodosLosPlu();
            if (plu != null)
            {
                var pluList = plu as List<ViewPluEnt> ?? plu.ToList();
                if (pluList.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pluList.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron plus registrados.");
        }


        [EnableQuery]
        [HttpGet]
        [Route("PLUSPorSucursal")]
        public HttpResponseMessage GetPluPorSucursal(short idSucursal)
        {
            var plu = _pluServices.PluPorSucursal(idSucursal);
            if (plu != null)
            {
                var pluList = plu as List<ViewPluEnt> ?? plu.ToList();
                if (pluList.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pluList.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron PLU's registrados para la sucursal indicada.");
        }
    }
}
