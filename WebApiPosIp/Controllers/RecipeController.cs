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
    public class RecipeController : ApiController
    {
        private readonly IRecipeServices _recipeServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de Recetas
        /// </summary>
        public RecipeController(IRecipeServices recipeservice)
        {
            _recipeServices = recipeservice;
        }

        #endregion

        //-----Controlador que muestra los detalles de una receta en especifico-----//
        [EnableQuery]
        [Route("allDetails")]//ruta especificada para el webapi
        public HttpResponseMessage Get(long idReceta)
        {
            var detalle = _recipeServices.GetRecipeDetail(idReceta);
            if (detalle != null)
            {
                var listDetalle = detalle as List<RecetaEnt> ?? detalle.ToList();
                if (listDetalle.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, listDetalle.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro el detalle de la receta indicada.");
        }

        //-- Controlador que retorna todas las recetas registradas para una Sucursal especifica --//
        [EnableQuery]
        [Route("RecetasDeSucursal")]
        public HttpResponseMessage GetRecetasPorSucursal(short idSucursal)
        {
            var listaRecetas = _recipeServices.RecetasPorSucursal(idSucursal);
            if(listaRecetas != null)
            {
                var recetas = listaRecetas as List<RecetaEnt> ?? listaRecetas.ToList();
                if (recetas.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, recetas.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro ninguna receta registrada para la sucursal indicada.");
        }

        //-----Controlador que muestra todos los detalles de todas las rectas registradas en la bd-----//
        [EnableQuery]
        [Route("allRecipesDetails")]//ruta especifica para el webapi
        public HttpResponseMessage Get()
        {
            var listaDetalles = _recipeServices.GetAllRecipeDetails();
            if(listaDetalles != null)
            {
                var listDet = listaDetalles as List<RecetaEnt> ?? listaDetalles.ToList();
                if (listDet.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, listDet.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron detalles de ninguna receta registrados.");
        }

        //------Controlador que retorna el un detalle en especifico de una receta-------//
        [EnableQuery]
        [Route("detail")]//ruta especifica para el web api
        public HttpResponseMessage Get(long idRecipe, long idProducto, short idSucursal)
        {
            var detalle = _recipeServices.GetRecipeDetail(idProducto, idRecipe, idSucursal);
            if (detalle != null)
                return Request.CreateResponse(HttpStatusCode.OK, detalle);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El detalle de receta indicado, no se encuentra registrado, por favor vuelva a intentarlo.");
        }

        //----------Controlador que inserta un nuevo detalle de receta en la bd-----------------------//
        [EnableQuery]
        [Route("newRecipeDetail")]//Ruta especificada para el webapi
        public string Post([FromBody] RecetaEnt nuevoDetalle)
        { 
            return _recipeServices.CreateRecipeDetail(nuevoDetalle);
        }

        //----------Controlador que actualiza un detalle de receta registrado en la bd-----------------//
        [EnableQuery]
        [Route("updateRecipeDetail")]//Ruta especifica para el webapi
        public string Put([FromBody]long idProducto, [FromBody]long idReceta, [FromBody]short idSucursal, [FromBody]RecetaEnt detalleReceta)
        {
            if (idProducto > 0)
            {
                return _recipeServices.UpdateRecipeDetail(idProducto, idReceta, idSucursal, detalleReceta);
            }
            return "Detalle de receta modificado exitosamente";
        }
    }
}
