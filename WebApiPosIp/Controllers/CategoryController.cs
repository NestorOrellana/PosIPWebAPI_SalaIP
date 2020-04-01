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
    [RoutePrefix("Category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryServices _categoryServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de categorias
        /// </summary>
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        #endregion

        //-----Controlador que muestra todas las categorias registradas en la bd-----//
        [EnableQuery]
        [Route("AllCategories")]//ruta especificada para el webapi
        public HttpResponseMessage Get()
        {
            var categorias = _categoryServices.GetAllCategories();
            if (categorias != null)
            {
                var categoryEntity = categorias as List<CategoriaEnt> ?? categorias.ToList();
                if (categoryEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, categoryEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron categorias registradas.");
        }

        //------Controlador que retorna una categoria basada en su id-------//
        [EnableQuery]
        [Route("CategoryById")]//ruta especificada para el webapi
        public HttpResponseMessage GetCategoryById(int idCategoria)
        {
            var categoria = _categoryServices.GetCategoryById(idCategoria);
            if (categoria != null)
                return Request.CreateResponse(HttpStatusCode.OK, categoria);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "La categoria indicada no se encuentra registrada.");
        }

        //------Controlador que inserta un registro de usuario en la bd-----//
        //[EnableQuery]
        [Route("Create")]//ruta especificada para el webapis
        public int Post([FromBody] CategoriaEnt newCategory)
        {
            return _categoryServices.CreateCategory(newCategory);
        }
    }
}
