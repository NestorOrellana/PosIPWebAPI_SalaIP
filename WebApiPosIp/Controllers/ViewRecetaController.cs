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
    public class ViewRecetaController : ApiController
    {
        private readonly IViewRecetaServices _recetaServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de la vista que retornara los datos del PLU
        /// </summary>
        public ViewRecetaController(IViewRecetaServices recetaServices)
        {
            _recetaServices = recetaServices;
        }

        #endregion

        [EnableQuery]
        [HttpGet]
        [Route("TodasLasRecetas")]//ruta especificada para el webapi
        public HttpResponseMessage TodasLasRecetas()
        {
            var receta = _recetaServices.TodasLasRecetas();
            if (receta != null)
            {
                var recetaList = receta as List<ViewRecetaEnt> ?? receta.ToList();
                if (recetaList.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, recetaList.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron recetas registradas.");
        }


        [EnableQuery]
        [HttpGet]
        [Route("RecetasPorSucursal")]
        public HttpResponseMessage RecetasPorSucursal(short idSucursal)
        {
            var receta = _recetaServices.RecetasPorSucursal(idSucursal);
            if (receta != null)
            {
                var listaReceta = receta as List<ViewRecetaEnt> ?? receta.ToList();
                if (listaReceta.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, listaReceta.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron Recetas registradas para la sucursal indicada.");
        }
    }
}
